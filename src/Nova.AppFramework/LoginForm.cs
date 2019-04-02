using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication;
using System.Threading;
using DevExpress.XtraEditors;
using System.Configuration;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Katrin.Win
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly string _urlProtocol = Uri.UriSchemeHttp + "://";
        private const string ParameterSettingName = "Parameter";
        private const string ServerUrlSettingName = "ServerUrl";

        public LoginForm()
        {
            InitializeComponent();
            autoLoginCheckEdit.CheckedChanged += AutoLoginCheckEditCheckedChanged;
            LoadState();
            if(autoLoginCheckEdit.Checked)
            {
                loginButton_Click(this,EventArgs.Empty);
            }
        }

        void AutoLoginCheckEditCheckedChanged(object sender, EventArgs e)
        {
            if (autoLoginCheckEdit.Checked) rememberPasswordCheckEdit.Checked = true;
        }

        private void LoadState()
        {
            const string stateId = "LoginSetting";
        }

        private string RemoveProtocal(string serverUrl)
        {
            if (serverUrl.StartsWith(_urlProtocol))
            {
                serverUrl = serverUrl.Remove(0, _urlProtocol.Length);
            }
            return serverUrl;
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
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
                return;

            SetBusyStatus(true);

            var loginAction = new Action<UserLoginResult>(VarifyUser);
            var parameter = CreateUserLoginParameter();
            var result = new UserLoginResult {Parameter = parameter};

            loginAction.BeginInvoke(result, LoginCallback, result);
        }

        private UserLoginParameter CreateUserLoginParameter()
        {
            var parameter = new UserLoginParameter()
                                {
                                    UserName = userNameTextEdit.Text,
                                    Password = passwordTextEdit.Text,
                                    ServerName = serverTextEdit.Text,
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
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Timeout = 15000;
            request.Method = "HEAD"; // As per Lasse's comment
            try
            {
                using (var response = (HttpWebResponse) request.GetResponse())
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
            loginButton.Enabled = !isBusy;
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
        }

        private void VarifyUser(UserLoginResult result)
        {
            string serverUrl = result.Parameter.ServerName;
            serverUrl = AppandProtocal(serverUrl);
            Uri serverUri;
            if (!Uri.TryCreate(serverUrl, UriKind.Absolute, out serverUri))
            {
                result.Message = "The server you entered is incorrect.";
                return;
            }
            bool isServerReachable = CheckConnection(serverUri);
            if (!isServerReachable)
            {
                result.Message = "The server you entered is not available.";
                return;
            }
            string loginPageUrl = serverUrl + (serverUrl.EndsWith("/") ? "" : "/") + "Login.aspx";
            bool isLogiPageAvaible = IsUrlReachable(loginPageUrl);
            if (!isLogiPageAvaible)
            {
                result.Message = "The server you entered is not available.";
                return;
            }

            UpdateSetting(ServerUrlSettingName, serverUrl);


            string userName = result.Parameter.UserName;
            string password = result.Parameter.Password;
            
        }

        private static void LoadMetadata()
        {
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
        public string Password { get; set; }
        public bool RememberPassword { get; set; }
        public bool AutoLogin { get; set; }
    }
}
