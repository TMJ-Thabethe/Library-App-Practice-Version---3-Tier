using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class BusinessLogicLayer
    {
        DataAccessLayer dal = new DataAccessLayer();

        //-----ROLE------//
        public DataTable GetRole()
        {
            return dal.GetRole();
        }

        //-----ADMIN-----//

        //-----Inserting Admin-----//
        public int InsertAdmin(AdminInfo admin)
        {
            return dal.InsertAdmin(admin);
        }

        //-----Updating Admin-----//
        public int UpdateAdmin(AdminInfo admin)
        {
            return dal.UpdateAdmin(admin);
        }

        //-----Getting Admin-----//
        public DataTable GetAdmin()
        {
            return dal.GetAdmin();
        }

        //-----Getting Admin Log Details-----//
        public DataTable GetAdminLogDetails(string username, string password)
        {
            return dal.GetAdminLogDetails(username, password);
        }

        //-----STUDENT-----//

        //----Inserting Student-----//
        public int InsertStudent(Student student)
        {
            return dal.InsertStudent(student);
        }

        //-----Updating Student-----//
        public int UpdateStudent(Student student)
        {
            return dal.UpdateStudent(student);
        }

        //-----Getting Student-----//
        public DataTable GetStudent()
        {
            return dal.GetStudent();
        }

        //-----Get Student Log Details-----//
        public DataTable GetStudentLogDetails(string username, string password)
        {
            return dal.GetStudentLogDetails(username, password);
        }

        //-----BOOK-----//

        //-----Insert Book-----//
        public int InsertBook(Book book)
        {
            return dal.InsertBook(book);
        }

        //-----Update Book-----//
        public int UpdateBook(Book book)
        {
            return dal.UpdateBook(book);
        }
        //-----Get Book-----//
        public DataTable GetBook()
        {
            return dal.GetBook();
        }

        //----Get Book By Genre-----//
        public DataTable GetBookByGenre(int genreID)
        {
            return dal.GetBookByGenre(genreID);
        }

        //-----Get Genre-----//
        public DataTable GetGenre()
        {
            return dal.GetGenre();
        }

        //-----REPORT-----//
        public DataTable GetStudentByRole(int studentID)
        {
            return dal.GetStudentByRole(studentID);
        }

        public DataTable GetAdminByRole(int adminID)
        {
            return dal.GetAdminByRole(adminID);
        }

        public DataTable SearchBook(Book book)
        {
            return dal.SearchBook(book);
        }
    }
}
