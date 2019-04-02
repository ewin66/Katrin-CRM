using System;
using System.Collections;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication;
using System.Threading;
using System.Web.ApplicationServices;
using System.Web.ClientServices.Providers;
using System.Web.Security;
using System.Windows.Forms;
using Katrin.Win.Common;
using Katrin.Win.Common.Security;
using Katrin.Win.Infrastructure.Services;
using Katrin.Win.Properties;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Services;
using DevExpress.XtraEditors;
using System.Configuration;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Net.Sockets;
using DevExpress.Data.Filtering;

namespace Katrin.Win
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm, IAuthenticationService
    {
        private readonly string _urlProtocol = Uri.UriSchemeHttp + "://";
        private const string ParameterSettingName = "Parameter";
        private const string ServerUrlSettingName = "ServerUrl";
        private const string ServiceUrlSettingName = "ServiceUrl";

        private readonly UserDataPersistenceService _persistenceService = new UserDataPersistenceService("LoginSetting");

        public LoginForm()
        {
            InitializeComponent();
            Icon = Resources.ri_Katrin;
            autoLoginCheckEdit.CheckedChanged += AutoLoginCheckEditCheckedChanged;
            LoadState();
            if (autoLoginCheckEdit.Checked)
            {
                loginButton_Click(this, EventArgs.Empty);
            }
        }

        void AutoLoginCheckEditCheckedChanged(object sender, EventArgs e)
        {
            if (autoLoginCheckEdit.Checked) rememberPasswordCheckEdit.Checked = true;
        }

        private void LoadState()
        {
            const string stateId = "LoginSetting";
            var parameter = (UserLoginParameter)_persistenceService[ParameterSettingName];

            if (parameter != null)
            {
                serverTextEdit.Text = parameter.ServerName;
                serviceTextEdit.Text = parameter.ServiceName;
                rememberPasswordCheckEdit.Checked = parameter.RememberPassword;
                autoLoginCheckEdit.Checked = parameter.AutoLogin;
                userNameTextEdit.Text = parameter.UserName;
                if (parameter.RememberPassword)
                    passwordTextEdit.Text = parameter.Password;
            }
            else
            {
                string serverUrl = ReadSetting(ServerUrlSettingName);
                string serviceUrl = ReadSetting(ServiceUrlSettingName);
                serverUrl = RemoveProtocal(serverUrl);
                serverTextEdit.Text = serverUrl;
                serviceTextEdit.Text = serviceUrl;
            }
        }

        private string RemoveProtocal(string serverUrl)
        {
            if (serverUrl.StartsWith(_urlProtocol))
            {
                serverUrl = serverUrl.Remove(0, _urlProtocol.Length);
            }
            return serverUrl;
        }

        public UserData SelectUser()
        {
            return DialogResult.OK == ShowDialog() ? new UserData() : null;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!string.IsNullOrEmpty(userNameTextEdit.Text)) passwordTextEdit.Focus();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            var parameter = CreateUserLoginParameter();
            parameter.ServerName = RemoveProtocal(parameter.ServerName);
            parameter.ServiceName = RemoveProtocal(parameter.ServiceName);
            _persistenceService[ParameterSettingName] = parameter;
            _persistenceService.Save();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
                return;

            SetBusyStatus(true);

            var loginAction = new Action<UserLoginResult>(VarifyUser);
            var parameter = CreateUserLoginParameter();
            var result = new UserLoginResult { Parameter = parameter };

            loginAction.BeginInvoke(result, LoginCallback, result);
            if (serverTextEdit.Text == "")
            {
                serverTextEdit.Focus();
            }

        }

        private UserLoginParameter CreateUserLoginParameter()
        {
            var parameter = new UserLoginParameter()
                                {
                                    UserName = userNameTextEdit.Text,
                                    Password = passwordTextEdit.Text,
                                    ServerName = serverTextEdit.Text,
                                    ServiceName = serviceTextEdit.Text,
                                    RememberPassword = rememberPasswordCheckEdit.Checked,
                                    AutoLogin = autoLoginCheckEdit.Checked
                                };
            return parameter;
        }

        private static void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        private static string ReadSetting(string key)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return configuration.AppSettings.Settings[key].Value;
        }

        private static bool CheckConnection(Uri serverUri)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                var result = socket.BeginConnect(serverUri.Host, serverUri.Port, null, null);
                bool success = result.AsyncWaitHandle.WaitOne(3000, true);

                return success;
            }
            finally
            {
                socket.Close();
            }
        }

        private static bool IsUrlReachable(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 15000;
            request.Method = "HEAD"; // As per Lasse's comment
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }

        private void SetBusyStatus(bool isBusy)
        {
            marqueeProgressBarControl1.Visible = isBusy;
            Cursor = isBusy ? Cursors.WaitCursor : Cursors.Default;
            loginButton.Enabled = !isBusy;
            serverTextEdit.Enabled = !isBusy;
            serviceTextEdit.Enabled = !isBusy;
            userNameTextEdit.Enabled = !isBusy;
            passwordTextEdit.Enabled = !isBusy;
            rememberPasswordCheckEdit.Enabled = !isBusy;
            autoLoginCheckEdit.Enabled = !isBusy;
        }

        private void LoginCallback(IAsyncResult ar)
        {
            Invoke(new Action(() => SetBusyStatus(false)));

            var result = (UserLoginResult)ar.AsyncState;

            if (result.Result)
            {
                Invoke(new Action(() =>
                                           {
                                               DialogResult = DialogResult.OK;
                                               Close();
                                           }));
            }
            else
            {
                ShowWarningMessage(result.Message);

            }
        }

        private static void ShowWarningMessage(string message)
        {
            XtraMessageBox.Show(message, Properties.Resources.Katrin, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void VarifyUser(UserLoginResult result)
        {

            if (result.Parameter.ServerName == "")
            {
                result.Message = "Please input the server name.";
                return;
            }
            string serverUrl = string.Empty;
            if (result.Parameter.ServiceName != "")
            { serverUrl = result.Parameter.ServerName + "/" + result.Parameter.ServiceName; }
            else
            {
                serverUrl = result.Parameter.ServerName;
            }
            serverUrl = AppandProtocal(serverUrl);
            Uri serverUri;
            if (!Uri.TryCreate(serverUrl, UriKind.Absolute, out serverUri))
            {
                result.Message = "The server or service you entered is incorrect.";
                return;
            }
            bool isServerReachable = CheckConnection(serverUri);
            if (!isServerReachable)
            {
                result.Message = "The server or service you entered is not available.";
                return;
            }
            string loginPageUrl = serverUrl + (serverUrl.EndsWith("/") ? "" : "/") + "Login.aspx";
            bool isLogiPageAvaible = IsUrlReachable(loginPageUrl);
            if (!isLogiPageAvaible)
            {
                result.Message = "The server or service you entered is not available.";
                return;
            }

            UpdateSetting(ServerUrlSettingName, serverUrl);

            LoadMetadata();

            string userName = result.Parameter.UserName;
            string password = result.Parameter.Password;
            var provider = (ClientFormsAuthenticationMembershipProvider)Membership.Provider;
            provider.ServiceUri = ConfigurationManager.AppSettings["ServerUrl"] + "/Authentication_JSON_AppService.axd";
            if (!Membership.ValidateUser(userName, password))
            {
                result.Message = "The username or password you entered is incorrect.";
                return;
            }
            try
            {

                var dynamicDataServiceContext = new DynamicDataServiceContext();
                CriteriaOperator userNameFilter = new BinaryOperator("UserName", userName);
                var user =
                    dynamicDataServiceContext.GetObjects("User", userNameFilter, null)._First();

                var userId = (Guid)user.GetType().GetProperty("UserId").GetValue(user, null);
                var fullName = (string)user.GetType().GetProperty("FullName").GetValue(user, null);
                var extraColumns = new Dictionary<string, string> { { "Role", "Role" } };
                var userRoles = dynamicDataServiceContext.GetObjects("UserRole", new BinaryOperator("UserId", userId), extraColumns);
                var currentRoles = userRoles.AsQueryable().Select("Role").ToArrayList();
                var userPrivileges = new List<Privilege>();
                foreach (var role in currentRoles)
                {
                    dynamicDataServiceContext.LoadProperty(role, "RolePrivileges");
                    var rolePrivileges = (IList)role.GetType().GetProperty("RolePrivileges").GetValue(role, null);
                    foreach (var rolePrivilege in rolePrivileges)
                    {
                        dynamicDataServiceContext.LoadProperty(rolePrivilege, "Privilege");
                        var privilege = rolePrivilege.GetType().GetProperty("Privilege").GetValue(rolePrivilege, null);
                        var name = (string)privilege.GetType().GetProperty("Name").GetValue(privilege, null);
                        dynamicDataServiceContext.LoadProperty(privilege, "PrivilegeEntities");
                        var privilegeEntities =
                            (IList)privilege.GetType().GetProperty("PrivilegeEntities").GetValue(privilege, null);
                        userPrivileges.AddRange(from object privilegeEntity in privilegeEntities
                                                select (string)privilegeEntity.GetType().GetProperty("EntityName")
                                                                    .GetValue(privilegeEntity, null)
                                                    into entityName
                                                    select new Privilege() { EntityName = entityName, Name = name });
                    }
                }

                var identity = new CustomIdentity(userId, userName, fullName);
                var principal = new CustomPrincipal(identity, userPrivileges.ToArray());
                AppDomain.CurrentDomain.SetThreadPrincipal(principal);
                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Message = BuildExceptionString(ex);
            }
        }

        private static void LoadMetadata()
        {
            MetadataProvider.Instance.LocalizedLabels.ToList();
            MetadataProvider.Instance.EntiyMetadata.ToList();
            MetadataProvider.Instance.EntityRelationshipRoles.ToList();
        }

        private string AppandProtocal(string serverUrl)
        {
            if (!serverUrl.StartsWith(Uri.UriSchemeHttp))
            {
                serverUrl = _urlProtocol + serverUrl;
            }
            return serverUrl;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void Authenticate()
        {
            IUserData user = SelectUser();
            if (user == null)
            {
                throw new AuthenticationException("NoUserProvidedForAuthentication");
            }
        }

        private static string BuildExceptionString(Exception exception)
        {
            string errMessage = string.Empty;

            errMessage += exception.Message + Environment.NewLine + exception.StackTrace;

            while (exception.InnerException != null)
            {
                errMessage += BuildInnerExceptionString(exception.InnerException);
                exception = exception.InnerException;
            }

            return errMessage;
        }

        private static string BuildInnerExceptionString(Exception innerException)
        {
            string errMessage = string.Empty;

            errMessage += Environment.NewLine + " InnerException ";
            errMessage += Environment.NewLine + innerException.Message + Environment.NewLine + innerException.StackTrace;

            return errMessage;
        }
    }

    public class UserLoginResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public UserLoginParameter Parameter { get; set; }
    }

    [Serializable]
    public class UserLoginParameter
    {
        public string UserName { get; set; }
        public string ServerName { get; set; }
        public string ServiceName { get; set; }
        public string Password { get; set; }
        public bool RememberPassword { get; set; }
        public bool AutoLogin { get; set; }
    }
}
