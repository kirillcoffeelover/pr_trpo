using System;
using System.Windows.Forms;
using MainApp.Panels;

namespace MainApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainFormLoad(object sender, EventArgs e)
        {
            ProgramData.headerPanel = new HeaderPanel();
            Controls.Add(ProgramData.headerPanel);

            ProgramData.loginPanel = new LoginPanel();
            Controls.Add(ProgramData.loginPanel);
            ProgramData.activePanel = ActivePanel.Login;

            ProgramData.MainPanelSetSize(this.Size, this.WindowState);
        }
        private void MainFormSizeChanged(object sender, EventArgs e)
        {
            ProgramData.MainPanelSetSize(this.Size, this.WindowState);
        }
        private void CloseForm(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
