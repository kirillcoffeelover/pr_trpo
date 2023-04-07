using System.Drawing;
using System.Windows.Forms;
using MainApp.TabPages;

namespace MainApp.Panels
{
    internal class AdminPanel : Panel
    {
        TabControl tabControl;
        ShowUserTab showUserTab;
        CreateNewUserTab createNewUserTab;
        AddNewEntryTab addNewEntryTab;
        public AdminPanel()
        {
            this.SuspendLayout();
            //
            //  this
            //
            this.Location = new Point(2, 62);
            this.BackColor = ProgramData.backColor;
            //
            //
            //
            createNewUserTab = new CreateNewUserTab();
            showUserTab = new ShowUserTab();
            addNewEntryTab = new AddNewEntryTab();
            //
            // tabControl
            //
            tabControl = new TabControl();
            tabControl.Location = new Point(0, 0);
            //
            //  tabControl.Controls
            //
            this.tabControl.Controls.Add(createNewUserTab);
            this.tabControl.Controls.Add(showUserTab);
            this.tabControl.Controls.Add(addNewEntryTab);
            //
            // Controls
            //
            this.Controls.Add(tabControl);
            //
            //
            //
            CalculateLocation(
                ProgramData.mainForm.Size,
                ProgramData.mainForm.WindowState);
            this.ResumeLayout();
        }
        public void CalculateLocation(
            Size size,
            FormWindowState windowState = FormWindowState.Maximized)
        {
            Size newSize = new Size(size.Width - 20, size.Height - 80);

            this.Size = newSize;
            tabControl.Size = newSize;

            createNewUserTab.CalculateLocation(newSize, windowState);
            addNewEntryTab.CalculateLocation(newSize, windowState);
            showUserTab.CalculateLocation(newSize, windowState);
        }
    }
}
