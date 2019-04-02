using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using ICSharpCode.Core;
using DevExpress.Data.Filtering;
using System.Security.Authentication;
using System.Web.Security;
using System.Web.ClientServices.Providers;
using System.Configuration;
using Katrin.AppFramework;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.Utils;
using System.Collections;
using Katrin.AppFramework.Security;
using System.Web;

namespace Katrin.Shell
{
    public partial class LoginForm : XtraForm
    {
        private Thread _loginThread;
        private bool _canCancel = false;
        private bool _loginSuccess = false;
        private readonly string _urlProtocol = Uri.UriSchemeHttp + "://";
        private const string ParameterSettingName = "Parameter";
        private const string ServerUrlSettingName = "ServerUrl";
        private const string ServiceUrlSettingName = "ServiceUrl";
        private static HttpWebRequest _request;

        public LoginForm()
        {
            //Debugger.Launch();
            InitializeComponent();
            autoLoginCheckEdit.CheckedChanged += AutoLoginCheckEditCheckedChanged;
            LoadState();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (autoLoginCheckEdit.Checked)
            {
                okButton_Click(this, EventArgs.Empty);
            }
        }

        void AutoLoginCheckEditCheckedChanged(object sender, EventArgs e)
        {
            if (autoLoginCheckEdit.Checked) rememberPasswordCheckEdit.Checked = true;
        }

        private void LoadState()
        {
            var parameter = PropertyService.Get<UserLoginParameter>("Document.ParameterSettingName", null);
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
            PropertyService.Set<UserLoginParameter>("Document.ParameterSettingName", parameter);
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
            _request = (HttpWebRequest)WebRequest.Create(url);

            _request.Timeout = 15000;
            _request.Method = "HEAD"; // As per Lasse's comment
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)_request.GetResponse())
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
            //marqueeProgressBarControl1.Visible = isBusy;
            if (isBusy)
            {
                LoadingFormManager.BeginLoading(this);
            }
            else
            {
                LoadingFormManager.EndLoading();
            }
            Cursor = isBusy ? Cursors.WaitCursor : Cursors.Default;

            okButton.Enabled = !isBusy;
            serverTextEdit.Enabled = !isBusy;
            serviceTextEdit.Enabled = !isBusy;
            userNameTextEdit.Enabled = !isBusy;
            passwordTextEdit.Enabled = !isBusy;
            rememberPasswordCheckEdit.Enabled = !isBusy;
            autoLoginCheckEdit.Enabled = !isBusy;
        }

        private void LoginCallback(UserLoginResult result)
        {
            Invoke(new Action(() => SetBusyStatus(false)));

            if (result.Result)
            {
                SecurityContext.IsLogon = true;

                Invoke(new Action(() =>
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }));
            }
            else
            {
                LoadingFormManager.EndLoading();
                ShowWarningMessage(result.Message);
            }
        }

        private static void ShowWarningMessage(string message)
        {
            XtraMessageBox.Show(message, StringParser.Parse("${res:Katrin}"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Login(object argument)
        {
            try
            {
                UserLoginResult result = (UserLoginResult)argument;
                VarifyUser(result);
                LoginCallback(result);
                if(result.Result)PropertyService.Save();

            }
            finally
            {
                _canCancel = false;
            }
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

            //LoadMetadata();

            string userName = result.Parameter.UserName;
            string password = result.Parameter.Password;
            var provider = (ClientFormsAuthenticationMembershipProvider)Membership.Provider;
            provider.ServiceUri = ConfigurationManager.AppSettings["ServerUrl"] + "/Authentication_JSON_AppService.axd";
            try
            {
                if (!Membership.ValidateUser(userName, password))
                {
                    result.Message = "The username or password you entered is incorrect.";
                    return;
                }


                IObjectSpace objectSpace = new ODataObjectSpace();
                CriteriaOperator userNameFilter = new BinaryOperator("UserName", userName);
                var user =
                    objectSpace.GetObjects("User", userNameFilter, null)._First();

                var userId = (Guid)user.GetType().GetProperty("UserId").GetValue(user, null);
                var fullName = (string)user.GetType().GetProperty("FullName").GetValue(user, null);
                var extraColumns = new Dictionary<string, string> { { "Role", "Role" } };
                var userRoles = objectSpace.GetObjects("UserRole", new BinaryOperator("UserId", userId), extraColumns);
                var currentRoles = userRoles.AsQueryable().Select("Role").ToArrayList();
                var userPrivileges = new List<Privilege>();
                List<Guid> roleIds = new List<Guid>();
                foreach (var roleObject in currentRoles)
                {
                    var role = (Katrin.Domain.Impl.Role)roleObject;
                    if (!roleIds.Contains(role.RoleId)) roleIds.Add(role.RoleId);
                    else continue;
                    objectSpace.LoadProperty(role, "RolePrivileges");

                    var rolePrivileges = role.RolePrivileges;
                    foreach (var rolePrivilege in rolePrivileges)
                    {
                        objectSpace.LoadProperty(rolePrivilege, "Privilege");
                        var privilege = rolePrivilege.Privilege;
                        var name = (string)privilege.Name;
                        objectSpace.LoadProperty(privilege, "PrivilegeEntities");
                        var privilegeEntities = privilege.PrivilegeEntities;
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
                _loginSuccess = true;
            }
            catch (ThreadAbortException)
            {
                //There just catch the abort exception and then leave this catch block.
            }
            catch (Exception ex)
            {
                //result.Message = BuildExceptionString(ex);
                result.Message = ex.Message;
                MessageService.ShowException(ex);
            }
        }

        private string AppandProtocal(string serverUrl)
        {
            if (!serverUrl.StartsWith(Uri.UriSchemeHttp))
            {
                serverUrl = _urlProtocol + serverUrl;
            }
            return serverUrl;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate())
                return;

            SetBusyStatus(true);

            var parameter = CreateUserLoginParameter();
            var result = new UserLoginResult { Parameter = parameter };

            _loginThread = new Thread(Login) { IsBackground = true };
            _canCancel = true;
            _loginThread.Start(result);

            if (serverTextEdit.Text == "")
            {
                serverTextEdit.Focus();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (_loginSuccess)
            {
                return;
            }
            if (_canCancel)
            {
                try
                {
                    cancelButton.Enabled = false;
                    if (_request != null)
                    {
                        _request.Abort();
                    }
                    _loginThread.Abort();
                    SetBusyStatus(false);
                }
                finally
                {
                    cancelButton.Enabled = true;
                }
            }
            else
            {
                Close();
            }
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

        private void userNameTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void serverTextEdit_EditValueChanged(object sender, EventArgs e)
        {

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
