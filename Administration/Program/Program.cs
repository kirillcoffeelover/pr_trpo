using System;
using System.Windows.Forms;
using MainApp.Forms;

namespace MainApp
{
static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ProgramData.mainForm = new MainForm();
        Application.Run(ProgramData.mainForm);
    }
}
}
