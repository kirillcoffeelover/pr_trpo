using System.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DBLib;
using MainApp.Forms;
using MainApp.Panels;

namespace MainApp
{
    internal enum ActivePanel
    {
        Login,
        User,
        Admin
    }
    enum HeaderState
    {
        LoggedIn,
        LoggedOut
    }
    internal enum PasswordState
    {
        Correct,
        Empty,
        TooShort,
        IllegalSymbols,
        DoesNotMatch
    }
    internal static class ProgramData
    {
        internal const int maximizedSizeOffset = 100;
        internal static DbWorker dbWorker;
        internal static ActivePanel activePanel;
        internal static MainForm mainForm;
        internal static HeaderPanel headerPanel;
        internal static LoginPanel loginPanel;
        internal static AdminPanel adminPanel;
        internal static Color backColor = SystemColors.ControlDark;
        internal static Color panelBackColor = SystemColors.ControlLight;
        internal static Color textBoxColor = SystemColors.ControlLightLight;
        internal static Color comboBoxColor = SystemColors.ControlLightLight;
        internal static Color headerBackColor = SystemColors.ControlDarkDark;
        internal static Color headerForeColor = Color.WhiteSmoke;
        internal static Color buttonBackColor = Color.RoyalBlue;
        internal static Color buttonForeColor = Color.White;
        internal const BorderStyle textBoxStyle = BorderStyle.FixedSingle;
        internal const ComboBoxStyle comboBoxStyle = ComboBoxStyle.DropDownList;
        internal const FlatStyle comboBoxFlatStyle = FlatStyle.Popup;
        internal const FlatStyle buttonStyle = FlatStyle.Popup;
        internal const FlatStyle radioButtonStyle = FlatStyle.Popup;
        internal static void MainPanelSetSize(Size size, FormWindowState windowState)
        {
            if (headerPanel != null)
                headerPanel.CalculateLocation(size, windowState);

            switch (activePanel)
            {
                case ActivePanel.Login:
                    {
                        if (loginPanel != null)
                            loginPanel.CalculateLocation(size, windowState);
                        break;
                    }
                case ActivePanel.Admin:
                    {
                        if (adminPanel != null)
                            adminPanel.CalculateLocation(size, windowState);
                        break;
                    }
            }
        }
        internal static void CloseCurrentPanel()
        {
            switch (activePanel)
            {
                case ActivePanel.Login:
                    {
                        mainForm.Controls.Remove(loginPanel);
                        loginPanel = null;
                        break;
                    }
                case ActivePanel.Admin:
                    {
                        mainForm.Controls.Remove(adminPanel);
                        adminPanel = null;
                        break;
                    }
            }
        }
        internal static string CreateNewLogin(
            ref List<string> existingValues,
            string name,
            string secondName,
            string lastName)
        {
            string login = string.Empty;

            login = string.Format("{0}.{1}{2}", name, secondName[0],
                                  (lastName == string.Empty ? string.Empty : "." + lastName[0]));

            if (existingValues.Contains(login))
            {
                long suffix = 1;
                while (existingValues.Contains(login + suffix.ToString()))
                    suffix++;
                login += suffix.ToString();
            }

            return login;
        }
        internal static bool CheckPhoneNumberCorrectness(string phoneNumber)
        {
            if (phoneNumber.Length == 15)
            {
                foreach (int i in new int[] { 1, 5, 9, 12 })
                    if (phoneNumber[i] != '-')
                        return false;
                foreach (int i in new int[] { 0, 2, 3, 4, 6, 7, 8, 10, 11, 13, 14 })
                    if (!char.IsDigit(phoneNumber[i]))
                        return false;
                return true;
            }
            else
                return false;
        }
        internal static bool CheckPasswordCorrectness(
            string passwordString,
            string confirmPasswordString,
            out PasswordState state)
        {

            if (string.IsNullOrWhiteSpace(passwordString))
            {
                state = PasswordState.Empty;
                return false;
            }

            foreach (char c in passwordString)
                if (char.IsWhiteSpace(c) || char.IsControl(c))
                {
                    state = PasswordState.IllegalSymbols;
                    return false;
                }

            if (passwordString.Length < 10)
            {
                state = PasswordState.TooShort;
                return false;
            }

            if (passwordString != confirmPasswordString)
            {
                state = PasswordState.DoesNotMatch;
                return false;
            }

            state = PasswordState.Correct;
            return true;
        }
        internal static int CheckLoginCorrectness(string login)
        {

            if (string.IsNullOrWhiteSpace(login))
            {
                return 1;
            }

            foreach (char c in login)
                if (char.IsWhiteSpace(c) || char.IsControl(c))
                {
                    return 2;
                }

            if (login.Length < 10)
            {
                return 3;
            }

            return 0;
        }
    }
}
