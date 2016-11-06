using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPS
{
    public partial class frmLogin : MetroFramework.Forms.MetroForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var usrname = this.txtUserName.Text;
                var password = this.txtPassword.Text;
                if (usrname == "")
                {
                    MessageBox.Show("username required", "login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtUserName.Focus();
                }
                else if (password == "")
                {
                    MessageBox.Show("password required", "login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtPassword.Focus();
                }
                else
                {
                    manageUsers myU = new manageUsers();
                    Boolean access = myU.loginUser(usrname, password);
                    if (access == true)
                    {
                        MessageBox.Show("Welcome" + usrname, "login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*setup sessions here*/
                        frmMainMenu myMenu = new frmMainMenu();
                        myMenu.ShowDialog();
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Creditials", "login Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtUserName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Applcation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
