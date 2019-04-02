using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Web;

namespace Katrin.Services.Security
{

    //Forms Authentication Ticket 
    public class CookieAuthenticationHttpModule : IHttpModule
    {

        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Recessive && HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
                return;
            HttpContext.Current.User =
                AuthenticateRequest(HttpContext.Current.Request.Cookies[CookieName], DateTime.Now, GetClientIP()) ??
                HttpContext.Current.User;
        }

        public String GetClientIP()
        {
            if (Transferrable)
            {
                return "any";
            }
            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }

        public void DeauthenticateRequest()
        {
            HttpContext.Current.User = null;
        }

        public HttpCookie GenerateLogoutCookie()
        {
            return GenerateCookie(null, new String[] { }, DateTime.Now.AddDays(-1), "0.0.0.0");
        }

        public static int RolesInCookie(HttpCookie c)
        {
            return int.Parse(c.Values["role-count"]);
        }

        public static String KeyForRole(int i)
        {
            return String.Format("role{0}", i);
        }

        public IPrincipal AuthenticateRequest(HttpCookie cookie, DateTime now, String clientIP)
        {
            if (!ValidP(cookie, now, clientIP))
            {
                return null;
            }
            var roles = new List<String>();
            for (int i = 0; i < RolesInCookie(cookie); ++i)
            {
                roles.Add(cookie.Values[KeyForRole(i)]);
            }
            return new GenericPrincipal(new GenericIdentity(cookie.Values["username"], CookieName), roles.ToArray());
        }

        public Boolean AuthenticatedThisWay(IPrincipal p)
        {
            return CookieName.Equals(p.Identity.AuthenticationType);
        }

        public Boolean ValidP(HttpCookie cookie, DateTime now, String clientIP)
        {
            if (ReferenceEquals(cookie, null)) return false;

            if (cookie.Values["client-ip"] != clientIP) return false;
            var expiry = ParseDateTime(cookie.Values["expiry"]);
            if (ReferenceEquals(expiry, null)) return false;
            if (expiry.Value < now) return false;

            var check =
                GenerateCookie(
                    cookie.Values["username"],
                    Enumerable.Range(0, RolesInCookie(cookie)).Select(i => cookie.Values[KeyForRole(i)]).ToArray(),
                    expiry.Value,
                    cookie.Values["client-ip"]);
            return cookie.Values.ToString().Equals(check.Values.ToString());
        }

        public HttpCookie GenerateCookie(String username, String[] roles, DateTime expiry, String clientIP)
        {
            var result = new HttpCookie(CookieName) {Expires = expiry};
            result.Values["username"] = username;
            result.Values["expiry"] = expiry.ToString(CultureInfo.InvariantCulture);
            result.Values["client-ip"] = clientIP;
            result.Values["role-count"] = roles.Length.ToString(CultureInfo.InvariantCulture);
            foreach (var r in roles.OrderBy(r => r).Select((r, i) => new {key = KeyForRole(i), value = r}))
            {
                result.Values[r.key] = r.value;
            }
            result.Values["sig"] = Sign(result.Values);
            return result;
        }

        public String Sign(NameValueCollection cookieValues)
        {
            using (var signer = new HMACSHA512(SigningKey))
            {
                var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                using (var ms = new System.IO.MemoryStream())
                {
                    bf.Serialize(ms, cookieValues);
                    ms.Seek(0, SeekOrigin.Begin);
                    return WriteKey(signer.ComputeHash(ms));
                }
            }
        }

        private DateTime? ParseDateTime(String dateTime)
        {
            DateTime result;
            if (!DateTime.TryParse(dateTime, out result)) return null;
            return result;
        }

        public String CookieName;
        public Byte[] SigningKey;
        public Boolean Recessive;
        public Boolean Transferrable;

        public CookieAuthenticationHttpModule() : this(null) { }

        public CookieAuthenticationHttpModule(NameValueCollection config)
        {
            Configure(config);
        }

        public static Byte[] ReadKey(String image)
        {
            var segments = image.Split('-');
            return segments.Select(bi => Byte.Parse(bi, System.Globalization.NumberStyles.AllowHexSpecifier)).ToArray();
        }

        public static String WriteKey(Byte[] key)
        {
            return BitConverter.ToString(key);
        }

        public void Configure(NameValueCollection config)
        {
            if (config == null) config = new NameValueCollection();
            CookieName = config[ConfigKey("cookieName")] ?? String.Format("{0}-token", this.GetType().FullName);
            var skConfigKey = ConfigKey("signingKey");
            if (config[skConfigKey] != null)
            {
                SigningKey = ReadKey(config[skConfigKey]);
            }
            else
            {
                lock (Syncroot)
                {
                    if (_sharedKey == null)
                    {
                        // see http://msdn.microsoft.com/en-us/library/w5y83hkf.aspx
                        // about key size
                        var sk = new Byte[64];
                        new RNGCryptoServiceProvider().GetBytes(sk);
                        _sharedKey = sk;
                    }
                }
                SigningKey = _sharedKey;
            }
            Recessive = boolFromConfigKey(config, ConfigKey("recessive"), false);
            Transferrable = boolFromConfigKey(config, ConfigKey("transferrable"), false);
        }

        public String ConfigKey(String setting)
        {
            return String.Format("{0}.{1}", GetType().FullName, setting);
        }

        private Boolean boolFromConfigKey(NameValueCollection config, String key, Boolean defaultValue)
        {
            String v = config[key];
            return v == null ? defaultValue : Boolean.Parse(v);
        }

        private static readonly Object Syncroot = new Object();
        /// <summary>
        /// If no signing key is configured, we'll
        /// generate a key on demand and share it
        /// amongst module instances that lack
        /// key config data.
        /// </summary>
        private static volatile Byte[] _sharedKey;

    }
}
