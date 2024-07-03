using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QbismLauncher.Utils;

namespace QbismLauncher.Forms
{
    partial class LauncherForm
    {
        #region Main Page
        private Button LaunchButton = null!;
        private ProgressBar Progress = null!;
        private TabPage HomePage = null!;
        #endregion

        #region Option Page
        private TextBox McPathTextBox = null!;
        private Button McPathButton = null!;
        private NumericUpDown RamInput = null!;
        private TabPage OptionPage = null!;
        #endregion

        #region Info Page
        private TabPage InfoPage = null!;
        #endregion

        private TabControl MainControl = null!;


        private void InitializeComponents()
        {
            LaunchButton = new Button()
            {
                Dock = DockStyle.Bottom,
                Text = "게임 시작",
                AutoSize = true,
            };

            LaunchButton.Click += LaunchButtonClick;

            Progress = new ProgressBar()
            {
                Dock = DockStyle.Bottom
            };

            HomePage = new TabPage()
            {
                Text = "실행",
                Padding = new Padding(10),
            };

            HomePage.Controls.Add(LaunchButton);
            HomePage.Controls.Add(Progress);

            McPathTextBox = new TextBox()
            {
                Dock = DockStyle.Fill,
                Text = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "profile"),
                ReadOnly = true,
            };

            McPathButton = new Button()
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                Text = "찾아보기",
            };

            McPathButton.Click += McPathButtonClick;

            var McPathGroup = new GroupBox()
            {
                Text = "설치 위치",
                Dock = DockStyle.Top,
                Padding = new Padding(5),
            };

            McPathGroup.Controls.Add(McPathTextBox);
            McPathGroup.Controls.Add(McPathButton);

            RamInput = new NumericUpDown()
            {
                Dock = DockStyle.Fill,
                Minimum = 4096,
                Maximum = ComputerInfo.Memory,
            };

            var RamLabel = new Label()
            {
                Dock = DockStyle.Right,
                AutoSize = true,
                Text = "MB",
                TextAlign = ContentAlignment.MiddleCenter,
            };

            var RamInputGroup = new GroupBox()
            {
                Text = "램",
                Dock = DockStyle.Top,
                Padding = new Padding(5),
            };

            RamInputGroup.Controls.Add(RamInput);
            RamInputGroup.Controls.Add(RamLabel);

            OptionPage = new TabPage()
            {
                Text = "설정",
                Padding = new Padding(10),
            };

            OptionPage.Controls.Add(RamInputGroup);
            OptionPage.Controls.Add(McPathGroup);

            Dictionary<string, List<string>> members = new()
            {
                { "Server Oper.", new() { "즈까락" }},
                { "SW Eng.", new() { "Gbunny", "Krapoi", "느니뉜" } },
                { "SW TPM", new() { "평누도민" } },
                { "PL", new() { "YBH" } },
                { "PM", new() { "버공" } },
            };

            InfoPage = new TabPage()
            {
                Text = "정보",
                Padding = new Padding(10),
                AutoScroll = true,
            };


            foreach (var (group, list) in members)
            {
                var groupbox = new GroupBox()
                {
                    Text = group,
                    Dock = DockStyle.Top,
                };

                foreach (var name in list)
                {
                    groupbox.Controls.Add(
                        new Label()
                        {
                            Text = name,
                            AutoSize = true,
                            Dock = DockStyle.Left,
                        }
                    );
                }

                InfoPage.Controls.Add(groupbox);
            }


            MainControl = new TabControl()
            {
                Dock = DockStyle.Fill,
            };

            MainControl.Controls.Add(HomePage);
            MainControl.Controls.Add(OptionPage);
            MainControl.Controls.Add(InfoPage);

            this.Controls.Add(MainControl);

            this.Size = new Size(512, 384);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Qbism Launcher";

            this.Font = new Font(Fonts.NanumGothic, 10);

            this.FormClosing += LauncherFormClosing;
        }
    }
}