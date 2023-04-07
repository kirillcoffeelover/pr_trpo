using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using DBLib;
using MainApp.Structs;

namespace MainApp.Panels
{
    internal class CreateNewUserPanel : Panel
    {
        private Label titleLabel;
        private RadioButton adminSwitch;
        private RadioButton userSwitch;
        private Label nameLabel;
        private Label secondNameLabel;
        private TextBox nameField;
        private TextBox secondNameField;
        private Label lastNameLabel;
        private Label loginLabel;
        private TextBox lastNameField;
        private TextBox loginField;
        private Label phoneNumberLabel;
        private Label emailAddressLabel;
        private TextBox phoneNumberField;
        private TextBox emailAddressField;
        private Label departmentLabel;
        private Label occupationLabel;
        private ComboBox departmentField;
        private ComboBox occupationField;
        private Label createPasswordLabel;
        private Label enterPasswordLabel;
        private Label confirmPasswordLabel;
        private TextBox confirmPasswordField;
        private TextBox enterPasswordField;
        private Button register;
        internal CreateNewUserPanel()
        {
            this.SuspendLayout();
            //
            // this
            //
            BackColor = ProgramData.panelBackColor;
            BorderStyle = ProgramData.textBoxStyle;
            //
            // location coordinates
            //
            const int fieldWidth = 150;
            const int col1X = 10;
            const int col2X = col1X + fieldWidth + 10;
            //
            int row1Y = 10;
            //
            // titleLabel
            //
            titleLabel = new Label();
            titleLabel.Location = new Point(col1X, row1Y);
            titleLabel.AutoSize = true;
            titleLabel.Font =
                new Font(
                    "Segoe UI",
                    15.75F,
                    FontStyle.Regular,
                    GraphicsUnit.Point);
            titleLabel.Text = "Регистрация";
            //
            int row2Y = row1Y + titleLabel.Height + 15;
            //
            // doctorSwitch
            //
            userSwitch = new RadioButton();
            userSwitch.FlatStyle = ProgramData.radioButtonStyle;
            userSwitch.Location = new Point(col1X + 10, row2Y);
            userSwitch.Text = "Пользователь";
            userSwitch.Width = fieldWidth - 10;
            //
            // adminSwitch
            //
            adminSwitch = new RadioButton();
            adminSwitch.FlatStyle = ProgramData.radioButtonStyle;
            adminSwitch.Location = new Point(col2X + 10, row2Y);
            adminSwitch.Text = "Администратор";
            adminSwitch.Width = fieldWidth - 10;
            //
            int row3Y = row2Y + adminSwitch.Height + 10;
            //
            // nameLabel
            //
            nameLabel = new Label();
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(col1X + 5, row3Y);
            nameLabel.Text = "Имя";
            //
            // secondNameLabel
            //
            secondNameLabel = new Label();
            secondNameLabel.AutoSize = true;
            secondNameLabel.Location = new Point(col2X + 5, row3Y);
            secondNameLabel.Text = "Фамилия";
            //
            int row4Y = row3Y + secondNameLabel.Height + 10;
            //
            // nameField
            //
            nameField = new TextBox();
            nameField.BackColor = ProgramData.textBoxColor;
            nameField.BorderStyle = ProgramData.textBoxStyle;
            nameField.Location = new Point(col1X, row4Y);
            nameField.Size = new Size(fieldWidth, 23);
            nameField.TextChanged += new EventHandler(FieldChanged);
            //
            // secondNameField
            //
            secondNameField = new TextBox();
            secondNameField.BackColor = ProgramData.textBoxColor;
            secondNameField.BorderStyle = ProgramData.textBoxStyle;
            secondNameField.Location = new Point(col2X, row4Y);
            secondNameField.Size = new Size(fieldWidth, 23);
            secondNameField.TextChanged += new EventHandler(FieldChanged);
            //
            int row5Y = row4Y + secondNameField.Height + 10;
            //
            // lastNameLabel
            //
            lastNameLabel = new Label();
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(col1X + 5, row5Y);
            lastNameLabel.Text = "Отчетсво";
            //
            // loginLabel
            //
            loginLabel = new Label();
            loginLabel.AutoSize = true;
            loginLabel.Location = new Point(col2X + 5, row5Y);
            loginLabel.Text = "Логин";
            //
            int row6Y = row5Y + loginLabel.Height + 10;
            //
            // lastNameField
            //
            lastNameField = new TextBox();
            lastNameField.BackColor = ProgramData.textBoxColor;
            lastNameField.BorderStyle = ProgramData.textBoxStyle;
            lastNameField.Location = new Point(col1X, row6Y);
            lastNameField.Size = new Size(fieldWidth, 23);
            lastNameField.TextChanged += new EventHandler(FieldChanged);
            //
            // loginField
            //
            loginField = new TextBox();
            loginField.BackColor = ProgramData.textBoxColor;
            loginField.BorderStyle = ProgramData.textBoxStyle;
            loginField.Location = new Point(col2X, row6Y);
            loginField.Size = new Size(fieldWidth, 23);
            loginField.TextChanged += new EventHandler(FieldChanged);
            //
            int row7Y = row6Y + loginField.Height + 10;
            //
            // phoneNumberLabel
            //
            phoneNumberLabel = new Label();
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(col1X + 5, row7Y);
            phoneNumberLabel.Text = "Номер телефона";
            //
            // emailAddressLabel
            //
            emailAddressLabel = new Label();
            emailAddressLabel.AutoSize = true;
            emailAddressLabel.Location = new Point(col2X + 5, row7Y);
            emailAddressLabel.Text = "Электронная почта";
            //
            int row8Y = row7Y + phoneNumberLabel.Height + 10;
            //
            // phoneNumberField
            //
            phoneNumberField = new TextBox();
            phoneNumberField.BackColor = ProgramData.textBoxColor;
            phoneNumberField.BorderStyle = ProgramData.textBoxStyle;
            phoneNumberField.Location = new Point(col1X, row8Y);
            phoneNumberField.Size = new Size(fieldWidth, 23);
            phoneNumberField.TextChanged += new EventHandler(FieldChanged);
            //
            // emailAddressField
            //
            emailAddressField = new TextBox();
            emailAddressField.BackColor = ProgramData.textBoxColor;
            emailAddressField.BorderStyle = ProgramData.textBoxStyle;
            emailAddressField.Location = new Point(col2X, row8Y);
            emailAddressField.Size = new Size(fieldWidth, 23);
            emailAddressField.TextChanged += new EventHandler(FieldChanged);
            //
            int row9Y = row8Y + phoneNumberField.Height + 10;
            //
            // specialisationLabel
            //
            departmentLabel = new Label();
            departmentLabel.AutoSize = true;
            departmentLabel.Location = new Point(col1X + 5, row9Y);
            departmentLabel.Text = "Отдел";
            //
            // occupationLabel
            //
            occupationLabel = new Label();
            occupationLabel.AutoSize = true;
            occupationLabel.Location = new Point(col2X + 5, row9Y);
            occupationLabel.Text = "Должность";
            //
            int row10Y = row9Y + departmentLabel.Height + 10;
            //
            // specialisationField
            //
            departmentField = new ComboBox();
            departmentField.BackColor = ProgramData.comboBoxColor;
            departmentField.DropDownStyle = ProgramData.comboBoxStyle;
            departmentField.FlatStyle = ProgramData.comboBoxFlatStyle;
            departmentField.Location = new Point(col1X, row10Y);
            departmentField.Size = new Size(fieldWidth, 23);
            departmentField.TextChanged += new EventHandler(FieldChanged);
            //
            // occupationField
            //
            occupationField = new ComboBox();
            occupationField.BackColor = ProgramData.comboBoxColor;
            occupationField.DropDownStyle = ProgramData.comboBoxStyle;
            occupationField.FlatStyle = ProgramData.comboBoxFlatStyle;
            occupationField.Location = new Point(col2X, row10Y);
            occupationField.Size = new Size(fieldWidth, 23);
            occupationField.TextChanged += new EventHandler(FieldChanged);
            //
            int row11Y = row10Y + departmentField.Height + 10;
            //
            // createPasswordLabel
            //
            createPasswordLabel = new Label();
            createPasswordLabel.AutoSize = true;
            createPasswordLabel.Font =
                new Font(
                    "Segoe UI",
                    15.75F,
                    FontStyle.Regular,
                    GraphicsUnit.Point);
            createPasswordLabel.Text = "Создайте Пароль";
            createPasswordLabel.Location = new Point(col1X, row11Y);
            //
            int row12Y = row11Y + createPasswordLabel.Height + 15;
            //
            // enterPasswordLabel
            //
            enterPasswordLabel = new Label();
            enterPasswordLabel.AutoSize = true;
            enterPasswordLabel.Location = new Point(col1X + 5, row12Y);
            enterPasswordLabel.Text = "Введите пароль";
            //
            int row13Y = row12Y + enterPasswordLabel.Height + 10;
            //
            // enterPasswordField
            //
            enterPasswordField = new TextBox();
            enterPasswordField.BackColor = ProgramData.textBoxColor;
            enterPasswordField.BorderStyle = ProgramData.textBoxStyle;
            enterPasswordField.Location = new Point(col1X, row13Y);
            enterPasswordField.PasswordChar = '*';
            enterPasswordField.Size = new Size(2 * fieldWidth + 10, 23);
            enterPasswordField.TextChanged += new EventHandler(FieldChanged);
            //
            int row14Y = row13Y + enterPasswordField.Height + 10;
            //
            // confirmPasswordLabel
            //
            confirmPasswordLabel = new Label();
            confirmPasswordLabel.AutoSize = true;
            confirmPasswordLabel.Location = new Point(col1X + 5, row14Y);
            confirmPasswordLabel.Text = "Повторите пароль";
            //
            int row15Y = row14Y + confirmPasswordLabel.Height + 10;
            //
            // confirmPasswordField
            //
            confirmPasswordField = new TextBox();
            confirmPasswordField.BackColor = ProgramData.textBoxColor;
            confirmPasswordField.BorderStyle = ProgramData.textBoxStyle;
            confirmPasswordField.Location = new Point(col1X, row15Y);
            confirmPasswordField.PasswordChar = '*';
            confirmPasswordField.Size = new Size(2 * fieldWidth + 10, 23);
            confirmPasswordField.TextChanged += new EventHandler(FieldChanged);
            //
            int row16Y = row15Y + confirmPasswordField.Height + 10;
            //
            // register
            //
            register = new Button();
            register.BackColor = ProgramData.buttonBackColor;
            register.ForeColor = ProgramData.buttonForeColor;
            register.FlatStyle = ProgramData.buttonStyle;
            register.Font =
                new Font(
                    "Segoe UI Black",
                    9.75F,
                    FontStyle.Bold,
                    GraphicsUnit.Point);
            register.Text = "Создать учетную запись";
            register.Enabled = false;
            register.Location = new Point(col1X, row16Y);
            register.Size = new Size(2 * fieldWidth + 10, 30);
            register.Click += new EventHandler(DoRegistration);
            //
            // this
            //
            Width = register.Width + col1X * 2;
            Height = register.Location.Y + register.Height + row1Y;
            //
            // Controls
            //
            Controls.Add(titleLabel);
            Controls.Add(adminSwitch);
            Controls.Add(userSwitch);
            Controls.Add(nameLabel);
            Controls.Add(secondNameLabel);
            Controls.Add(nameField);
            Controls.Add(secondNameField);
            Controls.Add(lastNameLabel);
            Controls.Add(loginLabel);
            Controls.Add(loginField);
            Controls.Add(lastNameField);
            Controls.Add(phoneNumberLabel);
            Controls.Add(emailAddressLabel);
            Controls.Add(phoneNumberField);
            Controls.Add(emailAddressField);
            Controls.Add(departmentLabel);
            Controls.Add(occupationLabel);
            Controls.Add(occupationField);
            Controls.Add(departmentField);
            Controls.Add(createPasswordLabel);
            Controls.Add(confirmPasswordLabel);
            Controls.Add(enterPasswordLabel);
            Controls.Add(enterPasswordField);
            Controls.Add(confirmPasswordField);
            Controls.Add(register);
            //
            // Post
            //
            this.ResumeLayout();
            LoadFields();
        }
        // Interface
        internal void ClearAllFields()
        {
            nameField.Text = string.Empty;
            secondNameField.Text = string.Empty;
            lastNameField.Text = string.Empty;
            loginField.Text = string.Empty;
            phoneNumberField.Text = string.Empty;
            emailAddressField.Text = string.Empty;
            departmentField.Items.Clear();
            occupationField.Items.Clear();
            confirmPasswordField.Text = string.Empty;
            enterPasswordField.Text = string.Empty;

            LoadFields();
        }
        internal void CalculateLocation(
            Size size,
            FormWindowState windowState = FormWindowState.Maximized)
        {
            titleLabel.Location = new Point(
                Width / 2 - titleLabel.Width / 2,
                titleLabel.Location.Y);

            createPasswordLabel.Location = new Point(
                Width / 2 - createPasswordLabel.Width / 2,
                createPasswordLabel.Location.Y);

            switch (windowState)
            {
                case FormWindowState.Maximized:
                    {
                        Location =
                        new Point(
                            size.Width / 2 - Width / 2,
                            size.Height / 2 - Height / 2
                                - ProgramData.maximizedSizeOffset / 2);
                        break;
                    }
                default:
                    {
                        Location = new Point(
                            size.Width / 2 - Width / 2,
                            size.Height / 2 - Height / 2);
                        break;
                    }
            }
        }
        private void LoadDepartments()
        {
            DbTableReader tableReader;
            string query = DbQueryCreator.SelectDepartments();

            try
            {
                tableReader = new DbTableReader(
                    new NpgsqlCommand(query, ProgramData.dbWorker.Connection).ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));

                return;
            }

            while (tableReader.ReadRow(out DbDataRow dataRow, DbParseMode.OutOnly))
                departmentField.Items.Add((string)dataRow.RowFields[0]);

            tableReader.Dispose();
        }
        private void LoadOccupations()
        {
            DbTableReader tableReader;
            string query = DbQueryCreator.SelectOccupations();

            try
            {

                tableReader =
                    new DbTableReader(
                        new NpgsqlCommand(query, ProgramData.dbWorker.Connection).ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));

                return;
            }

            while (tableReader.ReadRow(out DbDataRow dataRow, DbParseMode.OutOnly))
                occupationField.Items.Add((string)dataRow.RowFields[0]);

            tableReader.Dispose();
        }
        private void LoadFields()
        {
            LoadDepartments();
            LoadOccupations();
        }
        private void FieldChanged(object sender = null, EventArgs e = null)
        {
            bool isNameGood = !string.IsNullOrWhiteSpace(nameField.Text);

            bool isSecondNameGood = !string.IsNullOrWhiteSpace(secondNameField.Text);

            bool isPhoneNumberGood = ProgramData.CheckPhoneNumberCorrectness(phoneNumberField.Text);

            bool isEmailAddressGood = !string.IsNullOrWhiteSpace(emailAddressField.Text);

            bool isDepartmentGood = departmentField.Items.Count > 0 && departmentField.SelectedIndex >= 0;

            bool isOccupationGood = occupationField.Items.Count > 0 && occupationField.SelectedIndex >= 0;

            bool isPasswordGood = ProgramData.CheckPasswordCorrectness(
                enterPasswordField.Text,
                confirmPasswordField.Text,
                out PasswordState passwordState);

            switch (passwordState)
            {
                case PasswordState.DoesNotMatch:
                    {
                        enterPasswordField.BackColor = Color.Red;
                        confirmPasswordField.BackColor = Color.Red;
                        break;
                    }
                case PasswordState.Empty:
                    {
                        enterPasswordField.BackColor = SystemColors.Control;
                        confirmPasswordField.BackColor = SystemColors.Control;
                        break;
                    }
                case PasswordState.TooShort:
                    {
                        enterPasswordField.BackColor = Color.Red;
                        confirmPasswordField.BackColor = Color.Red;
                        break;
                    }
                case PasswordState.IllegalSymbols:
                    {
                        enterPasswordField.BackColor = Color.Red;
                        confirmPasswordField.BackColor = Color.Red;
                        break;
                    }
                case PasswordState.Correct:
                    {
                        enterPasswordField.BackColor = SystemColors.Control;
                        confirmPasswordField.BackColor = SystemColors.Control;
                        break;
                    }
            }

            if (isNameGood
            && isSecondNameGood
            && isPhoneNumberGood
            && isEmailAddressGood
            && isDepartmentGood
            && isOccupationGood
            && isPasswordGood)
                register.Enabled = true;
            else
                register.Enabled = false;
        }
        private bool GetExistingLogins(ref List<string> list)
        {
            DbTableReader tableReader;

            string query = DbQueryCreator.SelectLogin();

            try
            {
                tableReader =
                    new DbTableReader(new NpgsqlCommand(query, ProgramData.dbWorker.Connection).ExecuteReader());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));

                return false;
            }

            while (tableReader.ReadRow(out DbDataRow dataRow, DbParseMode.OutOnly))
                list.Add((string)dataRow.RowFields[0]);

            tableReader.Dispose();

            return true;
        }
        private void GetNewLogin(out string login, ref UserInfo userInfo, ref List<string> list)
        {
            string manualLogin = userInfo.Login;
            string newLogin = string.Empty;

            if (manualLogin == string.Empty)
            {
                newLogin =
                    ProgramData.CreateNewLogin(
                        ref list,
                        userInfo.FirstName,
                        userInfo.SecondName,
                        userInfo.LastName);
            }
            else if (list.Contains(manualLogin))
            {
                MessageBox.Show(
                    string.Format(
                        "Пользователь с логином {0} уже существует!",
                        manualLogin),
                    "Ошибка регистрации",
                    MessageBoxButtons.OK);
            }
            else
                newLogin = manualLogin;

            login = newLogin;
        }
        private bool InsertIntoUserInfo(ref UserInfo userInfo)
        {
            string query =
            DbQueryCreator.InsertIntoUserInfo(
                userInfo.Login,
                userInfo.FirstName,
                userInfo.SecondName,
                userInfo.LastName,
                userInfo.PhoneNumber,
                userInfo.EmailAddress,
                userInfo.Department,
                userInfo.Occupation,
                userInfo.Status);

            try
            {
                new NpgsqlCommand(query, ProgramData.dbWorker.Connection).ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));

                return false;
            }

            return true;
        }
        private bool InsertIntoUsers(ref Users users)
        {
            string query =
            DbQueryCreator.InsertIntoUsers(
                users.Role,
                users.Login,
                users.Password);

            try
            {
                new NpgsqlCommand(query, ProgramData.dbWorker.Connection).ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));

                return false;
            }

            return true;
        }
        private void DoRegistration(object sender = null, EventArgs e = null)
        {
            UserInfo userInfo = new()
            {
                Login = loginField.Text,
                FirstName = nameField.Text,
                SecondName = secondNameField.Text,
                LastName = lastNameField.Text,
                PhoneNumber = phoneNumberField.Text,
                EmailAddress = emailAddressField.Text,
                Department = departmentField.Text,
                Occupation = occupationField.Text,
                Status = "Default"
            };

            Users users = new()
            {
                Login = string.Empty,
                Password = confirmPasswordField.Text,
                Role = UserRole.Invalid
            };

            List<string> existingLogins = new List<string>();

            if (adminSwitch.Checked)
                users.Role = UserRole.Admin;
            else if (userSwitch.Checked)
                users.Role = UserRole.Common;

            if (users.Role == UserRole.Invalid)
            {
                MessageBox.Show(
                    "Укажите роль пользователя",
                    "Не указана роль пользователя",
                    MessageBoxButtons.OK);

                return;
            }

            if (!GetExistingLogins(ref existingLogins))
                return;

            GetNewLogin(out userInfo.Login, ref userInfo, ref existingLogins);

            if (string.IsNullOrWhiteSpace(userInfo.Login))
            {
                MessageBox.Show(
                    "Укажите имя пользователя",
                    "Имя пользователя",
                    MessageBoxButtons.OK);

                return;
            }
            else
                users.Login = userInfo.Login;

            if (!InsertIntoUserInfo(ref userInfo))
                return;

            if (!InsertIntoUsers(ref users))
                return;

            ClearAllFields();
        }
    }
}
