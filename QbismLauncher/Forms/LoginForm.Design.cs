using System;
using System.Drawing;
using System.Windows.Forms;

namespace QbismLauncher.Forms
{
    partial class LoginForm
    {
        private Button LoginButton = null!;

        private void InitializeComponents()
        {
            LoginButton = new Button
            {
                Dock = DockStyle.Top,
                Text = "Microsoft 로그인",
                Font = new Font(Fonts.NanumGothicExtraBold, 32),
                AutoSize = true,
            };
            LoginButton.Click += LoginButtonClick;

            this.Controls.Add(LoginButton);

            this.Size = new Size(512, 384);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Qbism Launcher";
            this.Load += LoginFormLoad;
            this.FormClosing += LoginFormClosing;
        }
    }
}