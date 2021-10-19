using BLL;
using System;
using System.Data;
using System.Windows.Forms;
using DAL;


namespace Library_App___3_Tier
{
    public partial class frmResources : Form
    {
        public frmResources()
        {
            InitializeComponent();
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

        BusinessLogicLayer bll = new BusinessLogicLayer();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void frmResources_Load(object sender, EventArgs e)
        {
            //-----Loading Genre-----//
            cmbGenre.DataSource = bll.GetGenre();
            cmbGenre.DisplayMember = "Genre";
            cmbGenre.ValueMember = "GenreID";

            //-----On run DataGridView-----//
            dgvResource.DataSource = bll.GetBook();

            //-----Counting the records-----//
            lblNumberOfRecords.Text = dgvResource.RowCount.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Book saved into your shelve!");
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you, GoodBye!!");

            frmSignIn frmResources = new frmSignIn();
            this.Hide();
            frmResources.Show();
        }

        private void dgvResourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvResource.SelectedRows.Count > 0)
            {

                lblISBN.Text = dgvResource.SelectedRows[0].Cells["ISBN"].Value.ToString() + "00-1834-5423";
                lblName.Text = dgvResource.SelectedRows[0].Cells["BookName"].Value.ToString();
                lblAuthor.Text = dgvResource.SelectedRows[0].Cells["BookAuthor"].Value.ToString();
            }
        }

        private void cmbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            int genreID;
            Int32.TryParse(cmbGenre.SelectedValue.ToString(), out genreID);
            dgvResource.DataSource = bll.GetBookByGenre(genreID);

            int row = 0;
            row = int.Parse(dgvResource.RowCount.ToString());
            row -= 1;

            lblNumberOfRecords.Text = row.ToString();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            //-----Displaying and Counting-----//
            dgvResource.DataSource = bll.GetBook();
            lblNumberOfRecords.Text = dgvResource.RowCount.ToString();
        }

        DataSet ds;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Book book = new Book();

            book.BookName = txtSearch.Text;

            dgvResource.DataSource = bll.SearchBook(book);
        }
    }
}
