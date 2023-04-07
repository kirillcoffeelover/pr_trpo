using System.Drawing;
using System.Windows.Forms;
using MainApp.Panels;

namespace MainApp.TabPages
{
    internal class AddNewEntryTab : TabPage
    {
        AddNewEntryPanel addNewEntryPanel;
        internal AddNewEntryTab()
        {
            //
            // this
            //
            this.BackColor = ProgramData.backColor;
            this.Text = "Внести новые значения";
            //
            // createNewUserPanel
            //
            addNewEntryPanel = new AddNewEntryPanel();
            //
            // Controls
            //
            this.Controls.Add(addNewEntryPanel);
        }
        internal void CalculateLocation(Size size, FormWindowState windowState = FormWindowState.Maximized)
        {
            this.Size = size;
            addNewEntryPanel.CalculateLocation(Size, windowState);
        }
    }
}
