using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using CmlLib.Core.Auth;
using CmlLib.Core.Auth.Microsoft;

namespace QbismLauncher.Forms
{
    partial class LoginForm : Form
    {
        public bool AutoLogin { get; set; } = true;
        public bool ExitOnClose { get; set; } = true;

        private readonly JELoginHandler loginHandler;

        public LoginForm()
        {
            loginHandler = JELoginHandlerBuilder.BuildDefault();
            InitializeComponents();
        }

        #region Events

        private async void LoginFormLoad(object? sender, EventArgs e)
        {
            Enabled = false;
            if (AutoLogin)
            {
                await TryAutoLogin();
            }
            Enabled = true;
        }

        private void LoginFormClosing(object? sender, EventArgs e)
        {
            if (ExitOnClose)
            {
                Environment.Exit(0);
            }
        }

        private async void LoginButtonClick(object? sender, EventArgs e)
        {
            Enabled = false;
            await TryLogin();
            Enabled = true;
        }

        #endregion

        private async Task TryAutoLogin()
        {
            MSession? session = null;
            try
            {
                session = await loginHandler.AuthenticateSilently();
            }
            catch (Exception)
            {
            }
            OpenLauncher(session);
        }

        private async Task TryLogin()
        {
            try
            {
                var session = await loginHandler.AuthenticateInteractively();
                OpenLauncher(session);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OpenLauncher(MSession? session)
        {
            var form = new LauncherForm()
            {
                Session = session,
            };
            form.Show();
            ExitOnClose = false;
            Close();
        }
    }
}