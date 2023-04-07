using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using DBLib;

namespace MainApp.Panels
{
    internal class LoginPanel : Panel
    {
        private int fieldWidth;
        private TextBox loginTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label titleLabel;
        private Label loginLabel;
        private Label passwordLabel;
        internal LoginPanel()
        {
            this.SuspendLayout();
            //
            // this
            //
            this.fieldWidth = 280;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = ProgramData.panelBackColor;
            //
            // titleLabel
            //
            this.titleLabel = new Label();
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            this.titleLabel.Location = new Point(0, 10);
            this.titleLabel.Text = "Вход";
            //
            // loginLabel
            //
            this.loginLabel = new Label();
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new Point(15, 40);
            this.loginLabel.Text = "Логин";
            //
            // loginTextBox
            //
            this.loginTextBox = new TextBox();
            this.loginTextBox.BackColor = ProgramData.textBoxColor;
            this.loginTextBox.BorderStyle = ProgramData.textBoxStyle;
            this.loginTextBox.Location = new Point(10, 60);
            this.loginTextBox.Size = new Size(fieldWidth, 23);
            this.loginTextBox.TextChanged += new EventHandler(this.FieldChanged);
            //
            // passwordLabel
            //
            this.passwordLabel = new Label();
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new Point(15, 90);
            this.passwordLabel.Text = "Пароль";
            //
            // passwordTextBox
            //
            this.passwordTextBox = new TextBox();
            this.passwordTextBox.BackColor = ProgramData.textBoxColor;
            this.passwordTextBox.BorderStyle = ProgramData.textBoxStyle;
            this.passwordTextBox.Location = new Point(10, 110);
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new Size(fieldWidth, 23);
            this.passwordTextBox.TextChanged += new EventHandler(this.FieldChanged);
            //
            // loginButton
            //
            this.loginButton = new Button();
            this.loginButton.BackColor = ProgramData.buttonBackColor;
            this.loginButton.ForeColor = ProgramData.buttonForeColor;
            this.loginButton.FlatStyle = ProgramData.buttonStyle;
            this.loginButton.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            this.loginButton.Text = "Войти";
            this.loginButton.Location = new Point(10, 150);
            this.loginButton.Size = new Size(fieldWidth, 30);
            this.loginButton.Enabled = false;
            this.loginButton.Click += new EventHandler(ClickLoginButton);
            //
            // LoginPanel
            //
            this.Size = new Size(fieldWidth + 20, loginButton.Location.Y + loginButton.Height + 10);
            //
            // Controls
            //
            Controls.Add(titleLabel);
            Controls.Add(loginLabel);
            Controls.Add(loginTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);
            //
            // Post
            //
            this.ResumeLayout();
            loginTextBox.Text = "default_manager";
            passwordTextBox.Text = "1234567890";
        }
        internal void ClearAllFields()
        {
            loginTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
        }
        internal void CalculateLocation(Size size, FormWindowState windowState = FormWindowState.Maximized)
        {
            this.titleLabel.Location = new Point(this.Width / 2 - titleLabel.Width / 2, titleLabel.Location.Y);

            switch (windowState)
            {
                case FormWindowState.Maximized:
                    {
                        Location = new Point(size.Width / 2 - Width / 2,
                                             size.Height / 2 - Height / 2 - ProgramData.maximizedSizeOffset / 2);
                        break;
                    }
                default:
                    {
                        Location = new Point(size.Width / 2 - Width / 2, size.Height / 2 - Height / 2);
                        break;
                    }
            }
        }
        public void FieldChanged(object sender, EventArgs e)
        {
            if (loginTextBox.Text.Length > 0)
                loginButton.Enabled = true;
            else
                loginButton.Enabled = false;
        }
        private int CheckPassword(string login, string password)
        {
            DbTableReader dbTableReader;
            string query = DbQueryCreator.SelectPassword(login);

            try
            {
                dbTableReader =
                    new DbTableReader(new NpgsqlCommand(query, ProgramData.dbWorker.Connection).ExecuteReader());
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("En error occuerd with message: {0}",
                                              DbWorker.DecodeNpgsqlException(e.Message), "Login error",
                                              MessageBoxButtons.OK));
                return -1;
            }

            bool matched = dbTableReader.ReadRow(out DbDataRow dataRow, DbParseMode.OutOnly) &&
                           dataRow.RowFields[0].ToString() == password;

            dbTableReader.Dispose();

            return matched ? 0 : 1;
        }
        private int CheckAccess(string login)
        {
            DbTableReader dbTableReader;
            string query = DbQueryCreator.SelectRole(login);
            try
            {
                dbTableReader =
                    new DbTableReader(new NpgsqlCommand(query, ProgramData.dbWorker.Connection).ExecuteReader());
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Текст ошибки: {0}", DbWorker.DecodeNpgsqlException(e.Message),
                                              "Ошибка во время запроса", MessageBoxButtons.OK));
                return -1;
            }

            bool matched = dbTableReader.ReadRow(out DbDataRow dataRow, DbParseMode.OutOnly) &&
                           dataRow.RowFields[0].ToString() == "Admin";

            dbTableReader.Dispose();

            return matched ? 0 : 1;
        }
        private void ClickLoginButton(object sender, EventArgs e)
        {
            if (ProgramData.dbWorker == null ||
                ProgramData.dbWorker.Connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    ProgramData.dbWorker = new DbWorker("localhost", "loli", "girlindress");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Текст ошибки: {0}", DbWorker.DecodeNpgsqlException(ex.Message),
                                                  "Ошибка во время запроса", MessageBoxButtons.OK));
                    return;
                }
            }

            switch (CheckAccess(loginTextBox.Text))
            {
                case -1:
                    {
                        return;
                    }
                case 1:
                    {
                        MessageBox.Show("У вас нет прав на доступ к системе.", "Отказано в доступе", MessageBoxButtons.OK);
                        return;
                    }
            }

            switch (CheckPassword(loginTextBox.Text, passwordTextBox.Text))
            {
                case -1:
                    {
                        return;
                    }
                case 1:
                    {
                        MessageBox.Show("Неверный логин или пароль!", "Ошибка авториазации", MessageBoxButtons.OK);
                        return;
                    }
            }

            ProgramData.CloseCurrentPanel();
            ProgramData.headerPanel.ChangeHeaderState(HeaderState.LoggedIn);
            ProgramData.adminPanel = new AdminPanel();
            ProgramData.mainForm.Controls.Add(ProgramData.adminPanel);
            ProgramData.adminPanel.CalculateLocation(ProgramData.mainForm.Size, ProgramData.mainForm.WindowState);
            ProgramData.activePanel = ActivePanel.Admin;
        }
    }
}
