using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class DataAccessLayer
    {
        static string connString = "Data Source = TMJ_Thabethe; Initial Catalog = LibraryDB; Integrated Security = true";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;

        //-----ROLE-----//

        //-----Getting Role----//
        public DataTable GetRole()
        {
            dbComm = new SqlCommand("sp_GetRole", dbConn);
            DataTable dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }

        //----ADMIN-----//
        
        //-----Inserting Admin------//
        public int InsertAdmin(AdminInfo admin)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_InsertAdmin", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Name", admin.Name);
            dbComm.Parameters.AddWithValue("@Surname", admin.Surname);
            dbComm.Parameters.AddWithValue("@Username", admin.Username);
            dbComm.Parameters.AddWithValue("@Password", admin.Password);
            dbComm.Parameters.AddWithValue("@RoleID", admin.RoleID);

            if(dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;

        }

        //----Updating Admin-----//
        public int UpdateAdmin(AdminInfo admin)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_UpdateAdmin", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@AdminID", admin.AdminID);
            dbComm.Parameters.AddWithValue("@Name", admin.Name);
            dbComm.Parameters.AddWithValue("@Surname", admin.Surname);
            dbComm.Parameters.AddWithValue("@Username", admin.Username);
            dbComm.Parameters.AddWithValue("@Password", admin.Password);
            dbComm.Parameters.AddWithValue("@RoleID", admin.RoleID);

            if (dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }

        //-----Get Admin-----//
        public DataTable GetAdmin()
        {
            dbComm = new SqlCommand("sp_GetAdmin", dbConn);
            DataTable dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }

        //-----Getting Admin Log Details-----//
        public DataTable GetAdminLogDetails(string username, string password)
        {
            dbComm = new SqlCommand("sp_GetAdminLogDetails", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Username", username);
            dbComm.Parameters.AddWithValue("@Password", password);

            DataTable dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }

        //-----STUDENT-----//

        //----Inserting Student------//
        public int InsertStudent(Student student)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_InsertStudent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Name", student.Name);
            dbComm.Parameters.AddWithValue("@Surname", student.Surname);
            dbComm.Parameters.AddWithValue("@Username", student.Username);
            dbComm.Parameters.AddWithValue("@Password", student.Password);
            dbComm.Parameters.AddWithValue("@RoleID", student.RoleID);

            if(dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }

        //-----Updating Student-----//
        public int UpdateStudent(Student student)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_UpdateStudent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@StudentID", student.StudentID);
            dbComm.Parameters.AddWithValue("@Name", student.Name);
            dbComm.Parameters.AddWithValue("@Surname", student.Surname);
            dbComm.Parameters.AddWithValue("@Username", student.Username);
            dbComm.Parameters.AddWithValue("@Password", student.Password);
            dbComm.Parameters.AddWithValue("@RoleID", student.RoleID);

            if (dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }

        //----Getting Student-----//
        public DataTable GetStudent()
        {
            dbComm = new SqlCommand("sp_GetStudent", dbConn);
            DataTable dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }

        //-----Getting Student Log Details-----//
        public DataTable GetStudentLogDetails(string username, string password)
        {
            dbComm = new SqlCommand("sp_GetStudentLogDetails", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Username", username);
            dbComm.Parameters.AddWithValue("@Password", password);

            DataTable dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);

            return dt;
        }

        //-----BOOK-----//

        //----Insert Book-----//
        public int InsertBook(Book book)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_InsertBook");
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@BookName", book.BookName);
            dbComm.Parameters.AddWithValue("@BookAuthor", book.BookAuthor);
            dbComm.Parameters.AddWithValue("@GenreID", book.GenreID);

            if(dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }

        //-----Update Book-----//
        public int UpdateBook(Book book)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_UpdateBook");
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ISBN", book.ISBN);
            dbComm.Parameters.AddWithValue("@BookName", book.BookName);
            dbComm.Parameters.AddWithValue("@BookAuthor", book.BookAuthor);
            dbComm.Parameters.AddWithValue("@GenreID", book.GenreID);

            if (dbConn.State == ConnectionState.Closed)
            {
                dbConn.Open();
            }

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();
            return x;
        }

        //-----Get Book-----//
        public DataTable GetBook()
        {
            dbComm = new SqlCommand("sp_GetBook", dbConn);
            DataTable dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }

        //-----Get Book By Genre-----//
        public DataTable GetBookByGenre(int genreID)
        {
            dbComm = new SqlCommand("sp_GetBookByGenre", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@GenreID", genreID);

            DataTable dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }

        //-----Get Genre-----//
        public DataTable GetGenre()
        {
            dbComm = new SqlCommand("sp_GetGenre", dbConn);
            DataTable dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }

        //-----REPORT-----//
        public DataTable GetStudentByRole(int studentID)
        {
            dbComm = new SqlCommand("sp_GetStudentByRole", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@StudentID", studentID);

            DataTable dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }

        public DataTable GetAdminByRole(int adminID)
        {
            dbComm = new SqlCommand("sp_GetAdminByRole", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@AdminID", adminID);

            DataTable dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }

        public DataTable SearchBook(Book book)
        {
            dbComm = new SqlCommand("sp_SearchBook", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@BookName", book.BookName);

            DataTable dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }

    }
}