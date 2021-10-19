using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace Library_App___3_Tier
{
    public partial class frmSignUp : Form
    {
        public frmSignUp()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();

        private void frmSignUp_Load(object sender, EventArgs e)
        {
            //-----Loading Role-----//
            cmbRole.DataSource = bll.GetRole();
            cmbRole.DisplayMember = "RoleDescription";
            cmbRole.ValueMember = "RoleID";

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
            Application.Exit();
        }

        //-----Inserting for both Student AND Admin-----//
        private void btnAdd_Click(object sender, EventArgs e)
        {

            string selected = this.cmbRole.GetItemText(this.cmbRole.SelectedItem);
            

            if(selected == "Admin")
            {
                //-----Inserting for Admin-----//
                AdminInfo admin = new AdminInfo();

                admin.Name = txtName.Text;
                admin.Surname = txtSurname.Text;
                admin.Username = txtUsername.Text;
                admin.Password = txtPassword.Text;
                admin.RoleID = int.Parse(cmbRole.SelectedValue.ToString());

                int x = bll.InsertAdmin(admin);


                if (x > 0)
                {
                    MessageBox.Show(x + " Admin record added!!");
                }
                else
                {
                    MessageBox.Show("No admin record added!!");
                }


                dgvUser.DataSource = bll.GetAdmin();
            }
            else if(selected == "Student")
            {
                //-----Inserting Student-----//
                Student student = new Student();

                student.Name = txtName.Text;
                student.Surname = txtSurname.Text;
                student.Username = txtUsername.Text;
                student.Password = txtPassword.Text;
                student.RoleID = int.Parse(cmbRole.SelectedValue.ToString());

                int x = bll.InsertStudent(student);

                if (x > 0)
                {
                    MessageBox.Show(x + " Student record added!!");
                }
                else
                {
                    MessageBox.Show("No student record added!!");
                }

                dgvUser.DataSource = bll.GetStudent();
            }

            //-----Clearing the fields------//
            txtName.Clear();
            txtSurname.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
    
        }

        //-----Updating for both Student AND Admin-----//
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string selected = this.cmbRole.GetItemText(this.cmbRole.SelectedItem);


            if (selected == "Admin")
            {
                //-----Inserting for Admin-----//
                AdminInfo admin = new AdminInfo();

                admin.AdminID = int.Parse(dgvUser.SelectedRows[0].Cells["AdminID"].Value.ToString());
                admin.Name = txtName.Text;
                admin.Surname = txtSurname.Text;
                admin.Username = txtUsername.Text;
                admin.Password = txtPassword.Text;
                admin.RoleID = int.Parse(cmbRole.SelectedValue.ToString());

                int x = bll.UpdateAdmin(admin);


                if (x > 0)
                {
                    MessageBox.Show(x + " Admin record added!!");
                }
                else
                {
                    MessageBox.Show("No admin record added!!");
                }


                dgvUser.DataSource = bll.GetAdmin();
            }
            else if (selected == "Student")
            {
                //-----Inserting Student-----//
                Student student = new Student();

                student.StudentID = int.Parse(dgvUser.SelectedRows[0].Cells["StudentID"].Value.ToString());
                student.Name = txtName.Text;
                student.Surname = txtSurname.Text;
                student.Username = txtUsername.Text;
                student.Password = txtPassword.Text;
                student.RoleID = int.Parse(cmbRole.SelectedValue.ToString());

                int x = bll.UpdateStudent(student);

                if (x > 0)
                {
                    MessageBox.Show(x + " Student record updated!!");
                }
                else
                {
                    MessageBox.Show("No student record updated!!");
                }

                dgvUser.DataSource = bll.GetStudent();
            }
        }
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            string selected = this.cmbRole.GetItemText(this.cmbRole.SelectedItem);

            if(selected == "Admin")
            {
                dgvUser.DataSource = bll.GetAdmin();
            }
            else
            {

                dgvUser.DataSource = bll.GetStudent();
            }

        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvUser.SelectedRows.Count > 0)
            {
                txtName.Text = dgvUser.SelectedRows[0].Cells["Name"].Value.ToString();
                txtSurname.Text = dgvUser.SelectedRows[0].Cells["Surname"].Value.ToString();
                txtUsername.Text = dgvUser.SelectedRows[0].Cells["Username"].Value.ToString();
                txtPassword.Text = dgvUser.SelectedRows[0].Cells["Password"].Value.ToString();
                cmbRole.Text = dgvUser.SelectedRows[0].Cells["RoleDescription"].Value.ToString();

                lblName.Text = dgvUser.SelectedRows[0].Cells["Name"].Value.ToString();
                lblSurname.Text = dgvUser.SelectedRows[0].Cells["Surname"].Value.ToString();
                lblRole.Text = dgvUser.SelectedRows[0].Cells["RoleDescription"].Value.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmWelcome frmSignUp = new frmWelcome();
            this.Hide();
            frmSignUp.Show();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            frmSignIn frmSignUp = new frmSignIn();
            this.Hide();
            frmSignUp.Show();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
