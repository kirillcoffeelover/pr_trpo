using System.Security.Cryptography;
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
    internal class ShowUserPanel : Panel
    {
        UserInfo userInfo;
        UserInfo userInfoModified = new();
        Users userLoginData;
        Users userLoginDataModified = new();
        Label titleLabel;
        Label selectUserLabel;
        ComboBox selectUserField;
        Label firstNameLabel;
        Label secondNameLabel;
        Label lastNameLabel;
        TextBox firstNameField;
        TextBox secondNameField;
        TextBox lastNameField;
        Label loginLabel;
        Label phoneNumberLabel;
        Label emailAddressLabel;
        TextBox loginField;
        TextBox phoneNumberField;
        TextBox emailAddressField;
        Label departmentLabel;
        Label occupationLabel;
        ComboBox departmentField;
        ComboBox occupationField;
        Label statusLabel;
        Label rolesLabel;
        ComboBox statusField;
        ComboBox rolesField;
        Label passwordLabel;
        Label enterPasswordLabel;
        TextBox enterPasswordField;
        Label confirmPasswordLabel;
        TextBox confirmPasswordField;
        Button updateEntryButton;
        internal ShowUserPanel()
        {
            this.SuspendLayout();
            //
            //  this
            //
            BackColor = ProgramData.panelBackColor;
            BorderStyle = ProgramData.textBoxStyle;
            //
            // location coordinates
            //
            const int fieldWidth = 150;
            const int col1X = 10;
            const int col2X = col1X + fieldWidth + 10;
            const int col3X = col2X + fieldWidth + 10;
            //
            int row1Y = 10;
            //
            //  titleLabel
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
            titleLabel.Text = "Изменение";
            //
            int row2Y = row1Y + titleLabel.Height + 10;
            //
            //  selectUserLabel
            //
            selectUserLabel = new Label();
            selectUserLabel.AutoSize = true;
            selectUserLabel.Location = new Point(col1X + 5, row2Y);
            selectUserLabel.Text = "Выберите пользователя";
            //
            int row3Y = row2Y + selectUserLabel.Height + 10;
            //
            //  selectUserField
            //
            selectUserField = new ComboBox();
            selectUserField.BackColor = ProgramData.comboBoxColor;
            selectUserField.DropDownStyle = ProgramData.comboBoxStyle;
            selectUserField.FlatStyle = ProgramData.comboBoxFlatStyle;
            selectUserField.Location = new Point(col1X, row3Y);
            selectUserField.Size = new Size(fieldWidth, 23);
            selectUserField.SelectedIndexChanged +=
                new EventHandler(UserChanged);
            //
            int row4Y = row3Y + selectUserField.Height + 10;
            //
            // firstNameLabel
            //
            firstNameLabel = new Label();
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(col1X + 5, row4Y);
            firstNameLabel.Text = "Имя";
            //
            // secondNameLabel
            //
            secondNameLabel = new Label();
            secondNameLabel.AutoSize = true;
            secondNameLabel.Location = new Point(col2X + 5, row4Y);
            secondNameLabel.Text = "Фамилия";
            //
            // lastNameLabel
            //
            lastNameLabel = new Label();
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(col3X + 5, row4Y);
            lastNameLabel.Text = "Отчетсво";
            //
            int row5Y = row4Y + firstNameLabel.Height + 10;
            //
            // firstNameField
            //
            firstNameField = new TextBox();
            firstNameField.BackColor = ProgramData.textBoxColor;
            firstNameField.BorderStyle = ProgramData.textBoxStyle;
            firstNameField.Location = new Point(col1X, row5Y);
            firstNameField.Size = new Size(fieldWidth, 23);
            //
            // secondNameField
            //
            secondNameField = new TextBox();
            secondNameField.BackColor = ProgramData.textBoxColor;
            secondNameField.BorderStyle = ProgramData.textBoxStyle;
            secondNameField.Location = new Point(col2X, row5Y);
            secondNameField.Size = new Size(fieldWidth, 23);
            //
            // lastNameField
            //
            lastNameField = new TextBox();
            lastNameField.BackColor = ProgramData.textBoxColor;
            lastNameField.BorderStyle = ProgramData.textBoxStyle;
            lastNameField.Location = new Point(col3X, row5Y);
            lastNameField.Size = new Size(fieldWidth, 23);
            //
            int row6Y = row5Y + firstNameField.Height + 10;
            //
            // loginLabel
            //
            loginLabel = new Label();
            loginLabel.AutoSize = true;
            loginLabel.Location = new Point(col1X + 5, row6Y);
            loginLabel.Text = "Логин";
            //
            // phoneNumberLabel
            //
            phoneNumberLabel = new Label();
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(col2X + 5, row6Y);
            phoneNumberLabel.Text = "Номер телефона";
            //
            // emailAddressLabel
            //
            emailAddressLabel = new Label();
            emailAddressLabel.AutoSize = true;
            emailAddressLabel.Location = new Point(col3X + 5, row6Y);
            emailAddressLabel.Text = "Электронная почта";
            //
            int row7Y = row6Y + loginLabel.Height + 10;
            //
            // loginField
            //
            loginField = new TextBox();
            loginField.BackColor = ProgramData.textBoxColor;
            loginField.BorderStyle = ProgramData.textBoxStyle;
            loginField.Location = new Point(col1X, row7Y);
            loginField.Size = new Size(fieldWidth, 23);
            loginField.TextChanged += new EventHandler(FieldChanged);
            //
            // phoneNumberField
            //
            phoneNumberField = new TextBox();
            phoneNumberField.BackColor = ProgramData.textBoxColor;
            phoneNumberField.BorderStyle = ProgramData.textBoxStyle;
            phoneNumberField.Location = new Point(col2X, row7Y);
            phoneNumberField.Size = new Size(fieldWidth, 23);
            phoneNumberField.TextChanged += new EventHandler(FieldChanged);
            //
            // emailAddressField
            //
            emailAddressField = new TextBox();
            emailAddressField.BackColor = ProgramData.textBoxColor;
            emailAddressField.BorderStyle = ProgramData.textBoxStyle;
            emailAddressField.Location = new Point(col3X, row7Y);
            emailAddressField.Size = new Size(fieldWidth, 23);
            //
            int row8Y = row7Y + loginField.Height + 10;
            //
            // specialisationLabel
            //
            departmentLabel = new Label();
            departmentLabel.AutoSize = true;
            departmentLabel.Location = new Point(col1X + 5, row8Y);
            departmentLabel.Text = "Отдел";
            //
            // occupationLabel
            //
            occupationLabel = new Label();
            occupationLabel.AutoSize = true;
            occupationLabel.Location = new Point(col2X + 5, row8Y);
            occupationLabel.Text = "Должность";
            //
            int row9Y = row8Y + departmentLabel.Height + 10;
            //
            // specialisationField
            //
            departmentField = new ComboBox();
            departmentField.BackColor = ProgramData.comboBoxColor;
            departmentField.DropDownStyle = ProgramData.comboBoxStyle;
            departmentField.FlatStyle = ProgramData.comboBoxFlatStyle;
            departmentField.Location = new Point(col1X, row9Y);
            departmentField.Size = new Size(fieldWidth, 23);
            //
            // occupationField
            //
            occupationField = new ComboBox();
            occupationField.BackColor = ProgramData.comboBoxColor;
            occupationField.DropDownStyle = ProgramData.comboBoxStyle;
            occupationField.FlatStyle = ProgramData.comboBoxFlatStyle;
            occupationField.Location = new Point(col2X, row9Y);
            occupationField.Size = new Size(fieldWidth, 23);
            //
            int row10Y = row9Y + departmentField.Height + 10;
            //
            // statusLabel
            //
            statusLabel = new Label();
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(col1X + 5, row10Y);
            statusLabel.Text = "Статус";
            //
            // rolesLabel
            //
            rolesLabel = new Label();
            rolesLabel.AutoSize = true;
            rolesLabel.Location = new Point(col2X + 5, row10Y);
            rolesLabel.Text = "Роль";
            //
            int row11Y = row10Y + statusLabel.Height + 10;
            //
            // statusField
            //
            statusField = new ComboBox();
            statusField.BackColor = ProgramData.comboBoxColor;
            statusField.DropDownStyle = ProgramData.comboBoxStyle;
            statusField.FlatStyle = ProgramData.comboBoxFlatStyle;
            statusField.Location = new Point(col1X, row11Y);
            statusField.Size = new Size(fieldWidth, 23);
            //
            // rolesField
            //
            rolesField = new ComboBox();
            rolesField.BackColor = ProgramData.comboBoxColor;
            rolesField.DropDownStyle = ProgramData.comboBoxStyle;
            rolesField.FlatStyle = ProgramData.comboBoxFlatStyle;
            rolesField.Location = new Point(col2X, row11Y);
            rolesField.Size = new Size(fieldWidth, 23);
            //
            int row12Y = row11Y + statusField.Height + 10;
            //
            //  passwordLabel
            //
            passwordLabel = new Label();
            passwordLabel.Location = new Point(col1X, row12Y);
            passwordLabel.AutoSize = true;
            passwordLabel.Font =
                new Font(
                    "Segoe UI",
                    15.75F,
                    FontStyle.Regular,
                    GraphicsUnit.Point);
            passwordLabel.Text = "Пароль";
            //
            int row13Y = row12Y + passwordLabel.Height + 10;
            //
            // enterPasswordLabel
            //
            enterPasswordLabel = new Label();
            enterPasswordLabel.AutoSize = true;
            enterPasswordLabel.Location = new Point(col1X + 5, row13Y);
            enterPasswordLabel.Text = "Введите пароль";
            //
            int row14Y = row13Y + enterPasswordLabel.Height + 10;
            //
            // enterPasswordField
            //
            enterPasswordField = new TextBox();
            enterPasswordField.BackColor = ProgramData.textBoxColor;
            enterPasswordField.BorderStyle = ProgramData.textBoxStyle;
            enterPasswordField.Location = new Point(col1X, row14Y);
            enterPasswordField.PasswordChar = '*';
            enterPasswordField.Size = new Size(3 * fieldWidth + 10 * 2, 23);
            enterPasswordField.TextChanged += new EventHandler(FieldChanged);
            //
            int row15Y = row14Y + enterPasswordField.Height + 10;
            //
            // confirmPasswordLabel
            //
            confirmPasswordLabel = new Label();
            confirmPasswordLabel.AutoSize = true;
            confirmPasswordLabel.Location = new Point(col1X + 5, row15Y);
            confirmPasswordLabel.Text = "Повторите пароль";
            //
            int row16Y = row15Y + confirmPasswordLabel.Height + 10;
            //
            // confirmPasswordField
            //
            confirmPasswordField = new TextBox();
            confirmPasswordField.BackColor = ProgramData.textBoxColor;
            confirmPasswordField.BorderStyle = ProgramData.textBoxStyle;
            confirmPasswordField.Location = new Point(col1X, row16Y);
            confirmPasswordField.PasswordChar = '*';
            confirmPasswordField.Size = new Size(3 * fieldWidth + 10 * 2, 23);
            confirmPasswordField.TextChanged += new EventHandler(FieldChanged);
            //
            int row17Y = row16Y + confirmPasswordField.Height + 10;
            //
            // updateEntryButton
            //
            updateEntryButton = new Button();
            updateEntryButton.BackColor = ProgramData.buttonBackColor;
            updateEntryButton.ForeColor = ProgramData.buttonForeColor;
            updateEntryButton.FlatStyle = ProgramData.buttonStyle;
            updateEntryButton.Font =
                new Font(
                    "Segoe UI Black",
                    9.75F,
                    FontStyle.Bold,
                    GraphicsUnit.Point);
            updateEntryButton.Text = "Внести изменения";
            updateEntryButton.Enabled = false;
            updateEntryButton.Location = new Point(col1X, row17Y);
            updateEntryButton.Size = new Size(3 * fieldWidth + 10 * 2, 30);
            updateEntryButton.Click += new EventHandler(UpdateUserInfo);
            //
            //  this
            //
            Width = updateEntryButton.Width + col1X * 2;
            Height = updateEntryButton.Location.Y + updateEntryButton.Height + row1Y;
            //
            //  Controls
            //
            this.Controls.Add(titleLabel);
            this.Controls.Add(selectUserLabel);
            this.Controls.Add(selectUserField);
            this.Controls.Add(firstNameLabel);
            this.Controls.Add(secondNameLabel);
            this.Controls.Add(lastNameLabel);
            this.Controls.Add(firstNameField);
            this.Controls.Add(secondNameField);
            this.Controls.Add(lastNameField);
            this.Controls.Add(loginLabel);
            this.Controls.Add(phoneNumberLabel);
            this.Controls.Add(emailAddressLabel);
            this.Controls.Add(loginField);
            this.Controls.Add(phoneNumberField);
            this.Controls.Add(emailAddressField);
            this.Controls.Add(departmentLabel);
            this.Controls.Add(occupationLabel);
            this.Controls.Add(departmentField);
            this.Controls.Add(occupationField);
            this.Controls.Add(statusLabel);
            this.Controls.Add(rolesLabel);
            this.Controls.Add(statusField);
            this.Controls.Add(rolesField);
            this.Controls.Add(passwordLabel);
            this.Controls.Add(enterPasswordLabel);
            this.Controls.Add(enterPasswordField);
            this.Controls.Add(confirmPasswordLabel);
            this.Controls.Add(confirmPasswordField);
            this.Controls.Add(updateEntryButton);
            //
            //  This
            //
            this.ResumeLayout();
            LoadFields();
        }
        internal void CalculateLocation(
            Size size,
            FormWindowState windowState = FormWindowState.Maximized)
        {
            titleLabel.Location = new Point(
                Width / 2 - titleLabel.Width / 2,
                titleLabel.Location.Y);

            passwordLabel.Location = new Point(
                Width / 2 - passwordLabel.Width / 2,
                passwordLabel.Location.Y);

            switch (windowState)
            {
                case FormWindowState.Maximized:
                    {
                        Location = new Point(
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
        private void LoadUsers()
        {
            DbTableReader tableReader;
            string query = DbQueryCreator.SelectLogin();

            try
            {
                tableReader = new DbTableReader(
                    new NpgsqlCommand(
                        query,
                        ProgramData.dbWorker.Connection).ExecuteReader());
                selectUserField.Items.Clear();
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

            while (tableReader.ReadRow(
                        out DbDataRow dataRow,
                        DbParseMode.OutOnly))
                selectUserField.Items.Add(dataRow.RowFields[0]);

            tableReader.Dispose();
        }
        private void LoadDepartments()
        {
            DbTableReader tableReader;
            string query = DbQueryCreator.SelectDepartments();

            try
            {
                tableReader = new DbTableReader(
                    new NpgsqlCommand(
                        query,
                        ProgramData.dbWorker.Connection).ExecuteReader());
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

            while (tableReader.ReadRow(
                    out DbDataRow dataRow,
                    DbParseMode.OutOnly))
                departmentField.Items.Add(dataRow.RowFields[0]);

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
                        new NpgsqlCommand(
                            query,
                            ProgramData.dbWorker.Connection).ExecuteReader());
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

            while (tableReader.ReadRow(
                    out DbDataRow dataRow,
                    DbParseMode.OutOnly))
                occupationField.Items.Add(dataRow.RowFields[0]);

            tableReader.Dispose();
        }
        private void LoadRoles()
        {
            DbTableReader tableReader;
            string query = DbQueryCreator.SelectRoles();

            try
            {
                tableReader =
                    new DbTableReader(
                        new NpgsqlCommand(
                            query,
                            ProgramData.dbWorker.Connection).ExecuteReader());
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

            while (tableReader.ReadRow(
                    out DbDataRow dataRow,
                    DbParseMode.OutOnly))
                rolesField.Items.Add(dataRow.RowFields[0]);

            tableReader.Dispose();
        }
        private void LoadStatuses()
        {
            DbTableReader tableReader;
            string query = DbQueryCreator.SelectStatuses();

            try
            {
                tableReader =
                    new DbTableReader(
                        new NpgsqlCommand(
                            query,
                            ProgramData.dbWorker.Connection).ExecuteReader());
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

            while (tableReader.ReadRow(
                    out DbDataRow dataRow,
                    DbParseMode.OutOnly))
                statusField.Items.Add(dataRow.RowFields[0]);

            tableReader.Dispose();
        }
        public void LoadFields()
        {
            LoadUsers();
            LoadDepartments();
            LoadOccupations();
            LoadStatuses();
            LoadRoles();
        }
        private void UserChanged(object sender = null, EventArgs e = null)
        {
            if (selectUserField.Items.Count == 0)
                return;

            string selectedLogin = selectUserField.SelectedItem.ToString();

            DbTableReader tableReader;
            string query = DbQueryCreator.SelectAllUserInfo(selectedLogin);

            try
            {
                tableReader =
                    new DbTableReader(
                        new NpgsqlCommand(
                            query,
                            ProgramData.dbWorker.Connection).ExecuteReader());
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

            if (tableReader.ReadRow(out DbDataRow dataRow, DbParseMode.OutOnly))
            {
                userInfo = new()
                {
                    Login = dataRow.RowFields[0].ToString(),
                    FirstName = dataRow.RowFields[2].ToString(),
                    SecondName = dataRow.RowFields[3].ToString(),
                    LastName = dataRow.RowFields[4].ToString(),
                    PhoneNumber = dataRow.RowFields[5].ToString(),
                    EmailAddress = dataRow.RowFields[6].ToString(),
                    Department = dataRow.RowFields[7].ToString(),
                    Occupation = dataRow.RowFields[8].ToString(),
                    Status = dataRow.RowFields[9].ToString(),
                };

                userLoginData = new()
                {
                    Login = dataRow.RowFields[0].ToString(),
                    Password = dataRow.RowFields[1].ToString()
                };

                switch (dataRow.RowFields[10].ToString())
                {
                    case "Admin":
                        {
                            userLoginData.Role = UserRole.Admin;
                            break;
                        }
                    case "Common":
                        {
                            userLoginData.Role = UserRole.Common;
                            break;
                        }
                    default:
                        {
                            userLoginData.Role = UserRole.Invalid;
                            break;
                        }
                }

                tableReader.Dispose();
            }
            else
            {
                tableReader.Dispose();
                return;
            }

            MapFields();
        }
        private void MapFields()
        {
            firstNameField.Text = userInfo.FirstName;
            secondNameField.Text = userInfo.SecondName;
            lastNameField.Text = userInfo.LastName;

            departmentField.SelectedIndex =
                MapIndex(ref departmentField, userInfo.Department);
            occupationField.SelectedIndex =
                MapIndex(ref occupationField, userInfo.Occupation);
            statusField.SelectedIndex =
                MapIndex(ref statusField, userInfo.Status);
            rolesField.SelectedIndex =
                MapIndex(ref rolesField, userLoginData.Role.ToString());

            loginField.Text = userLoginData.Login;
            phoneNumberField.Text = userInfo.PhoneNumber;
            emailAddressField.Text = userInfo.EmailAddress;
        }
        private int MapIndex(ref ComboBox comboBox, string value)
        {
            int index;
            if ((index = comboBox.Items.IndexOf(value)) < 0)
            {
                index = comboBox.Items.IndexOf("Default");
            }
            return index;
        }
        private void SaveFields()
        {
            userInfoModified.Login = loginField.Text;
            userInfoModified.FirstName = firstNameField.Text;
            userInfoModified.SecondName = secondNameField.Text;
            userInfoModified.LastName = lastNameField.Text;
            userInfoModified.PhoneNumber = phoneNumberField.Text;
            userInfoModified.EmailAddress = emailAddressField.Text;
            userInfoModified.Department = departmentField.SelectedItem.ToString();
            userInfoModified.Occupation = occupationField.SelectedItem.ToString();
            userInfoModified.Status = statusField.SelectedItem.ToString();

            userLoginDataModified.Login = loginField.Text;
            userLoginDataModified.Password = enterPasswordField.Text;

            switch (rolesField.SelectedItem.ToString())
            {
                case "Admin":
                    {
                        userLoginDataModified.Role = UserRole.Admin;
                        break;
                    }
                case "Common":
                    {
                        userLoginDataModified.Role = UserRole.Common;
                        break;
                    }
                default:
                    {
                        userLoginDataModified.Role = UserRole.Invalid;
                        break;
                    }
            }
        }

        private void FieldChanged(object sender = null, EventArgs e = null)
        {
            SaveFields();

            bool isLoginGood = false;

            if (userLoginData.Login != userLoginDataModified.Login)
            {
                if (ProgramData.CheckLoginCorrectness(userLoginDataModified.Login) == 0)
                    isLoginGood = true;
                else
                    isLoginGood = false;
            }
            else
                isLoginGood = true;

            bool isPasswordGood = false;
            PasswordState passwordState = PasswordState.Correct;

            if (userLoginDataModified.Password == string.Empty)
                isPasswordGood = true;
            else
            {
                isPasswordGood = ProgramData.CheckPasswordCorrectness(
                    userLoginDataModified.Password,
                    confirmPasswordField.Text,
                    out passwordState);

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
            }

            bool isPhoneNumberGood = false;

            if (userInfo.PhoneNumber != userInfoModified.PhoneNumber)
                isPhoneNumberGood =
                    ProgramData.CheckPhoneNumberCorrectness(userInfoModified.PhoneNumber);
            else
                isPhoneNumberGood = true;

            if (isLoginGood
            && isPasswordGood
            && isPhoneNumberGood)
                updateEntryButton.Enabled = true;
            else
                updateEntryButton.Enabled = false;
        }
        private void UpdateUserInfo(object sender = null, EventArgs e = null)
        {
            SaveFields();

            MessageBox.Show(string.Format(
                "{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}\n{9}\n{10}\n",
                userInfoModified.Login,
                userInfoModified.FirstName,
                userInfoModified.SecondName,
                userInfoModified.LastName,
                userInfoModified.PhoneNumber,
                userInfoModified.EmailAddress,
                userInfoModified.Department,
                userInfoModified.Occupation,
                userInfoModified.Status,
                userLoginDataModified.Role,
                userLoginDataModified.Password));

            bool justMap = true;

            if (userInfo.Login != userInfoModified.Login)
            {
                justMap = false;
                UpdateLogin();
            }

            if (!string.IsNullOrWhiteSpace(userLoginDataModified.Password))
                UpdatePassword();

            if (userInfo.FirstName != userInfoModified.FirstName)
                UpdateFirstName();

            if (userInfo.SecondName != userInfoModified.SecondName)
                UpdateSecondName();

            if (userInfo.LastName != userInfoModified.LastName)
                UpdateLastName();

            if (userInfo.PhoneNumber != userInfoModified.PhoneNumber)
                UpdatePhoneNumber();

            if (userInfo.EmailAddress != userInfoModified.EmailAddress)
                UpdateEmailAddress();

            if (userInfo.Department != userInfoModified.Department)
                UpdateDepartment();

            if (userInfo.Occupation != userInfoModified.Occupation)
                UpdateOccupation();

            if (userInfo.Status != userInfoModified.Status)
                UpdateStatus();

            UserRole newRole = UserRole.Invalid;

            switch (rolesField.SelectedItem.ToString())
            {
                case "Admin":
                    {
                        newRole = UserRole.Admin;
                        break;
                    }
                case "Common":
                    {
                        newRole = UserRole.Common;
                        break;
                    }
                default:
                    {
                        newRole = UserRole.Invalid;
                        break;
                    }
            }

            userLoginDataModified.Role = newRole;

            if (userLoginData.Role != userLoginDataModified.Role)
                UpdateRole();

            if (justMap)
                MapFields();
            else
            {
                string newLogin = userInfo.Login;
                LoadUsers();
                selectUserField.SelectedIndex = selectUserField.Items.IndexOf(newLogin);
            }
        }
        private void UpdateLogin()
        {
            string query
                = DbQueryCreator.UpdateUserInfoLogin(
                    userInfo.Login,
                    userInfoModified.Login
                );
            MessageBox.Show(query);
            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();
                userInfo.Login = userInfoModified.Login;
                userLoginData.Login = userInfoModified.Login;
                userLoginDataModified.Login = userInfoModified.Login;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));
            }
        }
        private void UpdatePassword()
        {
            string query
                = DbQueryCreator.UpdateUsersPassword(
                    userInfo.Login,
                    userLoginDataModified.Password
                );
            MessageBox.Show(query);
            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();
                userLoginDataModified.Password = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));
            }
        }
        private void UpdateFirstName()
        {
            string query
                = DbQueryCreator.UpdateUserInfoFirstName(
                    userInfo.Login,
                    userInfoModified.FirstName
                );
            MessageBox.Show(query);
            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();
                userInfo.FirstName = userInfoModified.FirstName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));
            }
        }
        private void UpdateSecondName()
        {
            string query
                = DbQueryCreator.UpdateUserInfoSecondName(
                    userInfo.Login,
                    userInfoModified.SecondName
                );
            MessageBox.Show(query);
            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();
                userInfo.SecondName = userInfoModified.SecondName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));
            }
        }
        private void UpdateLastName()
        {
            string query
                = DbQueryCreator.UpdateUserInfoLastName(
                    userInfo.Login,
                    userInfoModified.LastName
                );
            MessageBox.Show(query);
            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();
                userInfo.LastName = userInfoModified.LastName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));
            }
        }
        private void UpdatePhoneNumber()
        {
            string query
                = DbQueryCreator.UpdateUserInfoPhoneNumber(
                    userInfo.Login,
                    userInfoModified.PhoneNumber
                );
            MessageBox.Show(query);
            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();
                userInfo.PhoneNumber = userInfoModified.PhoneNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));
            }
        }
        private void UpdateEmailAddress()
        {
            string query
                = DbQueryCreator.UpdateUserInfoEmailAddress(
                    userInfo.Login,
                    userInfoModified.EmailAddress
                );
            MessageBox.Show(query);
            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();
                userInfo.EmailAddress = userInfoModified.EmailAddress;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));
            }
        }
        private void UpdateDepartment()
        {
            string query
                = DbQueryCreator.UpdateUserInfoDepartment(
                    userInfo.Login,
                    userInfoModified.Department
                );
            MessageBox.Show(query);
            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();
                userInfo.Department = userInfoModified.Department;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));
            }
        }
        private void UpdateOccupation()
        {
            string query
                = DbQueryCreator.UpdateUserInfoOccupation(
                    userInfo.Login,
                    userInfoModified.Occupation
                );
            MessageBox.Show(query);
            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();
                userInfo.Occupation = userInfoModified.Occupation;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));
            }
        }
        private void UpdateStatus()
        {
            string query
                = DbQueryCreator.UpdateUserInfoStatus(
                    userInfo.Login,
                    userInfoModified.Status
                );
            MessageBox.Show(query);
            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();
                userInfo.Status = userInfoModified.Status;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));
            }
        }
        private void UpdateRole()
        {
            string query
                = DbQueryCreator.UpdateUsersRole(
                    userInfo.Login,
                    rolesField.SelectedItem.ToString()
                );
            MessageBox.Show(query);
            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();
                userLoginData.Role = userLoginDataModified.Role;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));
            }
        }
    }
}
