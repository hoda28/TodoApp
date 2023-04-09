using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoApp
{
    public partial class MainForm : Form
    {

        #region Fields
        private Button currentButton;
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void ActivateButton(object btnSender)
        { 
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = Color.FromArgb(255, 23, 68);
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.FromArgb(245, 245, 245);
                    currentButton.Font = new System.Drawing.Font("Orbitron", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                previousBtn.BackColor = Color.FromArgb(66, 66, 66);
                previousBtn.ForeColor = Color.WhiteSmoke;
                previousBtn.Font = new System.Drawing.Font("Orbitron", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        #region Panel Menu

        #region btnAll_Click()
        private void btnAll_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }
        #endregion

        #region btnPending_Click()
        private void btnPending_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }
        #endregion

        #region btnComp_Click()
        private void btnComp_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }
        #endregion

        #region btnManage_Click()
        private void btnManage_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }
        #endregion

        #endregion

        #endregion
        #region btnNew_Click()
        private void btnNew_Click(object sender, EventArgs e)
        {
            EditForm form = new EditForm();
            form.ShowDialog();
        }
        #endregion
    }
}
