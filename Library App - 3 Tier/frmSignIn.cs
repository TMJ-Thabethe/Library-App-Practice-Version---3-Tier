using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace Library_App___3_Tier
{
    public partial class frmSignIn : Form
    {
        public frmSignIn()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        
        private void frmSignIn_Load(object sender, EventArgs e)
        {

        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (rbtnStudent.Checked)
            {
                DataTable dt = bll.GetStudentLogDetails(txtUsername.Text, txtPassword.Text);

                if(dt.Rows.Count > 0)
                {
                    frmResources frmSignIn = new frmResources();
                    this.Hide();
                    frmSignIn.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect sign in Information!");

                    //-----Clearing the fields-----//
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
            }
            else if(rbtnAdmin.Checked)
            {
                DataTable dt = bll.GetAdminLogDetails(txtUsername.Text, txtPassword.Text);

                if(dt.Rows.Count > 0)
                {
                    frmAdmin frmSignIn = new frmAdmin();
                    this.Hide();
                    frmSignIn.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect sign in Information!");
                    
                    //-----Clearing the fields-----//
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
            }
            else
            {
                MessageBox.Show("User required, Student or Admin!");
            }
        }







        private void rbtnStudent_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
