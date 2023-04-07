using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using DBLib;

namespace MainApp.Panels
{
    internal class AddNewEntryPanel : Panel
    {
        List<string> existingValues = new List<string>();
        Label selectTableLabel;
        ComboBox selectTableField;
        Label newEntryLabel;
        TextBox newEntryField;
        Label newEntryStatus;
        Button addEntryButton;
        internal AddNewEntryPanel()
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
            //  selectTableLabel
            //
            selectTableLabel = new Label();
            selectTableLabel.AutoSize = true;
            selectTableLabel.Location = new Point(col1X + 5, row1Y);
            selectTableLabel.Text = "Выберите таблицу";
            //
            int row2Y = row1Y + selectTableLabel.Height + 10;
            //
            //  selectTableField
            //
            selectTableField = new ComboBox();
            selectTableField.BackColor = ProgramData.textBoxColor;
            selectTableField.DropDownStyle = ProgramData.comboBoxStyle;
            selectTableField.FlatStyle = ProgramData.comboBoxFlatStyle;
            selectTableField.Items.AddRange(new string[]{
                "Roles",
                "Departments",
                "Occupations",
                "Statuses"});
            selectTableField.Location = new Point(col1X, row2Y);
            selectTableField.Size = new Size(fieldWidth, 23);
            selectTableField.SelectedIndexChanged +=
                new EventHandler(ChangeTable);
            //
            int row3Y = row2Y + selectTableField.Height + 10;
            //
            //  newEntryLabel
            //
            newEntryLabel = new Label();
            newEntryLabel.AutoSize = true;
            newEntryLabel.Location = new Point(col1X + 5, row3Y);
            newEntryLabel.Text = string.Empty;
            //
            int row4Y = row3Y + newEntryLabel.Height + 10;
            //
            // newEntryField
            //
            newEntryField = new TextBox();
            newEntryField.BackColor = ProgramData.textBoxColor;
            newEntryField.BorderStyle = ProgramData.textBoxStyle;
            newEntryField.Enabled = false;
            newEntryField.Location = new Point(col1X, row4Y);
            newEntryField.Size = new Size(fieldWidth, 23);
            newEntryField.TextChanged += new EventHandler(CheckNewEntry);
            //
            // newEntryStatus
            //
            newEntryStatus = new Label();
            newEntryStatus.AutoSize = true;
            newEntryStatus.Location = new Point(col2X, row4Y);
            newEntryStatus.Text = "Введите значение";
            //
            int row5Y = row4Y + newEntryField.Height + 10;
            //
            // addNewEntryButton
            //
            addEntryButton = new Button();
            addEntryButton.BackColor = ProgramData.buttonBackColor;
            addEntryButton.ForeColor = ProgramData.buttonForeColor;
            addEntryButton.FlatStyle = ProgramData.buttonStyle;
            addEntryButton.Font =
                new Font(
                    "Segoe UI Black",
                    9.75F,
                    FontStyle.Bold,
                    GraphicsUnit.Point);
            addEntryButton.Text = "Добавить";
            addEntryButton.Enabled = false;
            addEntryButton.Location = new Point(col1X, row5Y);
            addEntryButton.Size = new Size(2 * fieldWidth + 10, 30);
            addEntryButton.Click += new EventHandler(AddNewEntry);
            //
            // this
            //
            Width = addEntryButton.Width + col1X * 2;
            Height = addEntryButton.Location.Y + addEntryButton.Height + row1Y;
            //
            //  Controls
            //
            this.Controls.Add(selectTableLabel);
            this.Controls.Add(selectTableField);
            this.Controls.Add(newEntryLabel);
            this.Controls.Add(newEntryField);
            this.Controls.Add(newEntryStatus);
            this.Controls.Add(addEntryButton);
            //
            //  this
            //
            this.ResumeLayout();
        }
        internal void CalculateLocation(
            Size size,
            FormWindowState windowState = FormWindowState.Maximized)
        {
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
        private void ChangeTable(object sender = null, EventArgs e = null)
        {
            DbTableReader tableReader;
            string query = string.Empty;

            existingValues.Clear();

            switch (selectTableField.SelectedItem?.ToString())
            {
                case "Occupations":
                    {
                        query = DbQueryCreator.SelectOccupations();
                        break;
                    }
                case "Departments":
                    {
                        query = DbQueryCreator.SelectDepartments();
                        break;
                    }
                case "Statuses":
                    {
                        query = DbQueryCreator.SelectStatuses();
                        break;
                    }
                case "Roles":
                    {
                        query = DbQueryCreator.SelectRoles();
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

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
                existingValues.Add((string)dataRow.RowFields[0]);

            tableReader.Dispose();

            if (selectTableField.SelectedIndex >= 0)
                newEntryField.Enabled = true;
        }
        private void CheckNewEntry(object sender = null, EventArgs e = null)
        {
            if (string.IsNullOrWhiteSpace(newEntryField.Text))
            {
                addEntryButton.Enabled = false;
                newEntryStatus.Text = "Введите значение";
            }
            else if (existingValues.Contains(newEntryField.Text))
            {
                addEntryButton.Enabled = false;
                newEntryStatus.Text = "Уже существует";
            }
            else
            {
                addEntryButton.Enabled = true;
                newEntryStatus.Text = "Нажмите \"Добавить\"";
            }

        }
        private void AddNewEntry(object sender = null, EventArgs e = null)
        {
            string query = string.Empty;

            switch (selectTableField.SelectedItem?.ToString())
            {
                case "Occupations":
                    {
                        query = DbQueryCreator.InsertIntoOccupations(newEntryField.Text);
                        break;
                    }
                case "Departments":
                    {
                        query = DbQueryCreator.InsertIntoDepartments(newEntryField.Text);
                        break;
                    }
                case "Statuses":
                    {
                        query = DbQueryCreator.InsertIntoStatuses(newEntryField.Text);
                        break;
                    }
                case "Roles":
                    {
                        query = DbQueryCreator.InsertIntoRoles(newEntryField.Text);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Таблица не выбрана");
                        return;
                    }
            }

            try
            {
                new NpgsqlCommand(
                    query,
                    ProgramData.dbWorker.Connection).ExecuteNonQuery();

                newEntryStatus.Text = "Добавлено!";
                ChangeTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Текст ошибки: {0}",
                        DbWorker.DecodeNpgsqlException(ex.Message),
                    "Ошибка во время запроса",
                    MessageBoxButtons.OK));

                newEntryStatus.Text = "Ошибка!";
            }
        }
    }
}
