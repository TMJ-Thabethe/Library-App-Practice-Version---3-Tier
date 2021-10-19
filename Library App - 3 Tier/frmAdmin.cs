using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace Library_App___3_Tier
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();

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

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            //-----Loading Roles-----//
            cmbRole.DataSource = bll.GetRole();
            cmbRole.DisplayMember = "RoleDescription";
            cmbRole.ValueMember = "RoleID";

            //-----Loading Genre-----//
            cmbGenre.DataSource = bll.GetGenre();
            cmbGenre.DisplayMember = "Genre";
            cmbGenre.ValueMember = "GenreID";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //-----Showing all Books-----//
            dgvInfo.DataSource = bll.GetBook();

            lblCountBooks.Text = dgvInfo.RowCount.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {

        }

        private void btnSoftDel_Click(object sender, EventArgs e)
        {

        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            frmWelcome frmAdmin = new frmWelcome();
            this.Hide();
            frmAdmin.Show();
        }

        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintDetails_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog(); //make a printDialog object
            PrintDocument printDocument = new PrintDocument(); // make a print doc object
            printDialog.Document = printDocument; //document for printing is printDocument
            printDocument.PrintPage += printDocument1_PrintPage; //event handler fire
            DialogResult result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dgvInfo.Width, this.dgvInfo.Height);

            dgvInfo.DrawToBitmap(bm, new Rectangle(0, 0, this.dgvInfo.Width, this.dgvInfo.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.cmbRole.GetItemText(this.cmbRole.SelectedItem);

            if (selected == "Student")
            {
                int studentID;
                Int32.TryParse(cmbRole.SelectedValue.ToString(), out studentID);
                dgvInfo.DataSource = bll.GetStudentByRole(studentID);
                dgvInfo.DataSource = bll.GetStudent();
                int countStudents = 0;
                countStudents = int.Parse(dgvInfo.RowCount.ToString());
                countStudents -= 1;

                lblCountStudents.Text = countStudents.ToString();

                lblCountAdmins.Text = "0";
                lblCountBooks.Text = "0";
            }
            else if(selected == "Admin")
            {
                int adminID;
                Int32.TryParse(cmbRole.SelectedValue.ToString(), out adminID);
                dgvInfo.DataSource = bll.GetAdminByRole(adminID);

                int countAdmin = 0;
                countAdmin = int.Parse(dgvInfo.RowCount.ToString());
                countAdmin -= 1;

                lblCountAdmins.Text = countAdmin.ToString();
                lblCountStudents.Text = "0";
                lblCountBooks.Text = "0";
            }
        }

        private void cmbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            int genreID;
            Int32.TryParse(cmbGenre.SelectedValue.ToString(), out genreID);
            dgvInfo.DataSource = bll.GetBookByGenre(genreID);

            int countBooks = 0;
            countBooks = int.Parse(dgvInfo.RowCount.ToString());
            countBooks -= 1;

            lblCountBooks.Text = countBooks.ToString();

            lblCountAdmins.Text = "0";
            lblCountStudents.Text = "0";
           
        }
    }
}
