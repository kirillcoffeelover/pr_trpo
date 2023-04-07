using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using DBLib;

namespace MainApp.Panels
{
    class HeaderPanel : Panel
    {
        private HeaderState state;
        private Label titleLabel;
        private Label exitLabel;
        public HeaderPanel()
        {
            this.state = HeaderState.LoggedOut;
            //
            // this
            //
            this.SuspendLayout();
            this.BackColor = ProgramData.headerBackColor;
            this.Location = new Point(0, 0);
            this.MinimumSize = new Size(0, 60);
            this.MaximumSize = new Size(ProgramData.mainForm.MaximumSize.Width, 60);
            this.Size = new Size(784, 60);
            //
            // exitLabel
            //
            this.titleLabel = new Label();
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            this.titleLabel.ForeColor = ProgramData.headerForeColor;
            this.titleLabel.Location = new Point(15, 15);
            this.titleLabel.Name = "RegistrationLabel";
            this.titleLabel.Text = "Адиминистрирование сотрудников";
            this.titleLabel.Click += new EventHandler(this.ClickExitLabel);
            //
            // exitLabel
            //
            this.exitLabel = new Label();
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            this.exitLabel.ForeColor = ProgramData.headerForeColor;
            this.exitLabel.Name = "RegistrationLabel";
            this.exitLabel.Text = "ВЫЙТИ";
            this.exitLabel.Location = new Point(this.Width - 15 - this.exitLabel.Width, 15);
            this.exitLabel.Click += new EventHandler(this.ClickExitLabel);
            //
            // Controls
            //
            this.Controls.Add(titleLabel);
            //
            // Post
            //
            this.ResumeLayout();
        }
        public void CalculateLocation(Size size, FormWindowState windowState = FormWindowState.Maximized)
        {
            this.Size = new Size(ProgramData.mainForm.Width, 60);

            switch (state)
            {
                case HeaderState.LoggedIn:
                    {
                        exitLabel.Location = new Point(ProgramData.mainForm.Width - exitLabel.Width - 20, 15);
                        break;
                    }
            }
        }
        internal void ChangeHeaderState(HeaderState state)
        {
            switch (state)
            {
                case HeaderState.LoggedIn:
                    {
                        Controls.Add(exitLabel);
                        break;
                    }
                case HeaderState.LoggedOut:
                    {
                        Controls.Remove(exitLabel);
                        break;
                    }
            }
            this.state = state;
            CalculateLocation(ProgramData.mainForm.Size, ProgramData.mainForm.WindowState);
        }
        private void ClickExitLabel(object sender = null, EventArgs e = null)
        {
            switch (MessageBox.Show("Вы выйдете из вашей учетной записи! Вы уверены?", "Выход из учетной записи",
                                    MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    {
                        ProgramData.dbWorker.Dispose();
                        ChangeHeaderState(HeaderState.LoggedOut);
                        LoadLoginPanel();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void LoadLoginPanel()
        {
            if (ProgramData.activePanel != ActivePanel.Login)
            {
                ProgramData.CloseCurrentPanel();
                ProgramData.loginPanel = new LoginPanel();
                ProgramData.mainForm.Controls.Add(ProgramData.loginPanel);
                ProgramData.loginPanel.CalculateLocation(ProgramData.mainForm.Size, ProgramData.mainForm.WindowState);
            }
            else
                ProgramData.loginPanel.ClearAllFields();
            ProgramData.activePanel = ActivePanel.Login;
        }
    }
}
