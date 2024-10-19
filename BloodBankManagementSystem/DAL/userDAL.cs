using BloodBankManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystem.DAL
{
    class userDAL
    {
        //Create a Static String to Connect Database
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public DataTable Select()
        {
            //create an object to connect database
            SqlConnection conn=new SqlConnection(myconnstrng);

            //create a database to hold the data from Database
            DataTable dt = new DataTable();
            try
            {
                //write sql query to get data from database
                String sql = "select * from tbl_users";

                //cretae sql command to execute query
                SqlCommand cmd= new SqlCommand(sql, conn);

                //cerate sql data adapter to hold the data from dtabase temproraly 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open Database connection
                conn.Open();    

                //transfer data from sqldata adapter to sql Datatable
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                //display message error if any error in connection
                MessageBox.Show(ex.Message);
            
            }
            finally
            {
                //close datbase connection
                conn.Close();
            }
            return dt;
        }

        #region insert data into database for user Module
        public bool insert(userBLL u)
        {
            //cretae a boolean variable and set it default value to false 
            bool isSuccess = false;

            //create an object of sql connection to connect database
           SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //cretae string variable to store the insert query
                String sql = "Insert into tbl_users (username,email,password,fullname,contact,address,added_date,image_name) values (@username,@email,@password,@fullname,@contact,@address,@added_date,@image_name)";
                //create a sql command to pass the value in our query  
                SqlCommand cmd=new SqlCommand(sql, conn);

                //create the parameters to pass the value from UI nad pass it on SQL query above
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@fullname", u.fullname);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@image_name", u.image_name);

                //open database connection
                conn.Open() ;

                //crete an integer variable to hold the value after the query is executed 
                int rows = cmd.ExecuteNonQuery();

                //the value of rows will be grater then 0 if the query is executed succesfully 
                //Else it will be 0
                if(rows > 0)
                {
                    //Query exetuted Succesfully
                    isSuccess = true;
                }
                else
                {
                    //Fialed to execute query 
                    isSuccess = false;
                }

            }
            catch (Exception ex) 
            {
                //display error message if there is any exceptional error
                MessageBox.Show(ex.Message);
            
            }
            finally 
            { 
                //close database connection
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
        #region update data in database(User Module)
        public bool update(userBLL u)
        {
            //cretae boolean variable and set its default value to false
            bool isSuccess = false;
            //cretae an object for database connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //cretae a string variable to hold the sql query 
                string sql = "update tbl_users set username=@username,email=@email,password=@password,fullname=@fullname,contact=@contact,address=@address,added_date=@added_date,image_name=@image_name where user_id=@user_id";

                //creat a sql comment to execute query and also pass the value to sql query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //pass the value to sql query
                cmd.Parameters.AddWithValue ("@username", u.username);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@fullname", u.fullname);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@image_name", u.image_name);
                cmd.Parameters.AddWithValue("@user_id",u.user_id);

                //create an integer variable to hold the value after the query is executed
                int rows = cmd.ExecuteNonQuery();

                //the value of rows will be grater then 0 if the query is executed succesfully 
                //Else it will be 0
                if (rows > 0)
                {
                    //Query exetuted Succesfully
                    isSuccess = true;
                }
                else
                {
                    //Fialed to execute query 
                    isSuccess = false;
                }
            }

            catch (Exception ex)
            {
                //display error message if there is any exceptional error 
                MessageBox.Show(ex.Message);
            }

            finally 
            { 
                //close database connection
                conn.Close();
            }


            return isSuccess;
        }



        #endregion

        #region delete data from database for our (user module)
        public bool Delete(userBLL u)
        {
            //cretae a boolean varible and set its default value to false
            bool isSuccess = false;

            //create an object for sql connection 
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //cretae a string to hold the sql query to delete data
                string sql = "DELETE from tbl_users where user_id=@user_id";
                //cretae sql command to execute the query

                SqlCommand cmd = new SqlCommand (sql, conn);

                //pass the value through parameters
                cmd.Parameters.AddWithValue("@user_id", u.user_id);
                //create a integer variable to hold the value after query is executed
                 int rows = cmd.ExecuteNonQuery();

                //the value of rows will be grater then 0 if the query is executed succesfully 
                //Else it will be 0
                if (rows > 0)
                {
                    //Query exetuted Succesfully
                    isSuccess = true;
                }
                else
                {
                    //Fialed to execute query 
                    isSuccess = false;
                }

            }

            catch (Exception ex)
            {
                //display error message if there is any exceptional error 
                MessageBox.Show(ex.Message);
            }
            finally
            { 
                conn.Close(); 
            }


            return isSuccess;
        }

        internal bool Insert(userBLL u)
        {
            throw new NotImplementedException();
        }

        internal userBLL GetIDFromUsername(string loggedInUser)
        {
            throw new NotImplementedException();
        }

        internal bool Update(userBLL u)
        {
            throw new NotImplementedException();
        }

        internal DataTable Search(string keywords)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
