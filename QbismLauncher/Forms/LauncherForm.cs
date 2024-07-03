using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Utils;

namespace QbismLauncher.Forms
{
    partial class LauncherForm : Form
    {
        public bool ExitOnClose { get; set; } = true;

        public MSession? Session { get; set; }

        private CMLauncher launcher;

        public LauncherForm()
        {
            launcher = new CMLauncher(new MinecraftPath(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "profile")));
            InitializeComponents();
            launcher.ProgressChanged += ProgressChanged;
        }

        #region Events 

        private void LauncherFormClosing(object? sender, EventArgs e)
        {
            if (ExitOnClose)
            {
                Environment.Exit(0);
            }
        }

        private async void LaunchButtonClick(object? sender, EventArgs e)
        {
            LaunchButton.Enabled = false;

            if (Session == null)
            {
                MessageBox.Show("로그인 후 이용할 수 있습니다");
                Logout();
            }
            else
            {
                try
                {
                    var process = await launcher.CreateProcessAsync("1.21", new MLaunchOption()
                    {
                        Session = Session,
                        ServerIp = "mc.hypixel.net"
                    });

                    var processUtil = new ProcessUtil(process);

                    processUtil.StartWithEvents();
                }
                catch (Exception)
                {
                    MessageBox.Show("실행에 실패했습니다");
                }
            }
            LaunchButton.Enabled = true;
        }

        private void ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            Progress.Maximum = 100;
            Progress.Value = e.ProgressPercentage;
        }

        private void McPathButtonClick(object? sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog()
            {
                SelectedPath = McPathTextBox.Text
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            McPathTextBox.Text = dialog.SelectedPath;
        }

        #endregion

        private void Logout()
        {
            ExitOnClose = false;
            var form = new LoginForm()
            {
                AutoLogin = false,
            };
            form.Show();
            this.Close();
        }
    }
}