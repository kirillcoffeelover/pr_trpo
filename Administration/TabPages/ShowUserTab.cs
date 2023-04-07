using System.Drawing;
using System.Windows.Forms;
using MainApp.Panels;

namespace MainApp.TabPages
{
    internal class ShowUserTab : TabPage
    {
        ShowUserPanel showUserPanel;
        internal ShowUserTab()
        {
            //
            // this
            //
            this.BackColor = ProgramData.backColor;
            this.Text = "Внести изменения в учетную запись пользователя";
            //
            // showUserPanel
            //
            showUserPanel = new ShowUserPanel();
            //
            // Controls
            //
            this.Controls.Add(showUserPanel);
        }
        internal void CalculateLocation(Size size, FormWindowState windowState = FormWindowState.Maximized)
        {
            this.Size = size;
            showUserPanel.CalculateLocation(Size, windowState);
        }
    }
}
