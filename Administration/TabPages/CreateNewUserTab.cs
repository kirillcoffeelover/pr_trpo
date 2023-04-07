using System.Drawing;
using System.Windows.Forms;
using MainApp.Panels;

namespace MainApp.TabPages
{
    internal class CreateNewUserTab : TabPage
    {
        CreateNewUserPanel createNewUserPanel;
        internal CreateNewUserTab()
        {
            //
            // this
            //
            this.BackColor = ProgramData.backColor;
            this.Text = "Добавить нового пользователя";
            //
            // createNewUserPanel
            //
            createNewUserPanel = new CreateNewUserPanel();
            //
            // Controls
            //
            this.Controls.Add(createNewUserPanel);
        }
        internal void CalculateLocation(Size size, FormWindowState windowState = FormWindowState.Maximized)
        {
            this.Size = size;
            createNewUserPanel.CalculateLocation(Size, windowState);
        }
    }
}
