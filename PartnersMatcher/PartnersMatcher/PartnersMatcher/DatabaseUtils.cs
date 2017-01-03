using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher
{
    class DatabaseUtils
    {

        OleDbConnection _dbConn;
        readonly string connectionError;

        public DatabaseUtils(string pathToDataBase)
        {
            _dbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathToDataBase + "; Persist Security Info=False");  // defining the source of the data base, meaning connection
            connectionError = "Connection error! try again later";
        }

        public void addUser(User user)
        {
            string email = user.Email;
            string firstName = user.FirstName;
            string lastName = user.LastName;
            string city = user.City;
            string pass = user.Pssword;
            string query = "insert into Users (User_Email,User_First_Name,User_Last_Name,User_city,User_password) values('" + email + "','" + firstName + "','" + lastName + "','" + city + "','" + pass + "')";
            if (checkIfEmailExistsInDb(email))
                throw new Exception(".האימייל כבר קיים במערכת");
            voidQueryToDB(query);   
        }
   
        public void addAd(Ad ad)
        {

            int number = ad.SerialNumber;
            string category = ad.Category;
            string location = ad.Lcation;
            string admin = ad.Admin;

            string query = "insert into Ad_table (Ad_numb,Ad_category,Ad_location,Ad_admin) values('" + number + "','" + category + "','" + location + "','" + admin + "')";
               
            voidQueryToDB(query);
        }

        public bool checkIfEmailExistsInDb(string email)
        {
            string query = "SELECT User_Email FROM Users WHERE User_Email = '" + email + "'";
            try
            {
                _dbConn.Open();
                OleDbCommand cmd = new OleDbCommand(query, _dbConn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                _dbConn.Close();
            }
            return false;
        }

        public User connectUser(string email, string pass)
        {
            User user = null;
            string query = "SELECT* FROM Users WHERE User_Email = '" + email + "'";

            string error = "", qEmail = "", qFname = "", qLname = "", qCity = "", qPass = "";
            try
            {
                _dbConn.Open();
                OleDbCommand cmd = new OleDbCommand(query, _dbConn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    qEmail = reader.GetValue(0).ToString();
                    qFname = reader.GetString(1);
                    qLname = reader.GetString(2);
                    qCity = reader.GetString(3);
                    qPass = reader.GetString(4);

                }
                if (qPass == "" || qPass != pass)
                    error = "Wrong Email or Password, please try again";
                else
                {
                    user = new User(email, qFname, qLname, qPass, qCity);
                    error = connectionError;
                }
            }
            catch (Exception)
            {
                throw new Exception(error);
            }
            finally
            {
                _dbConn.Close();
            }
            return user;
        }

        public List<Ad> getAdsByLocationAndCategory(string location, string category)
        {
            List<Ad> listOfAds = null;

            string query = "SELECT* FROM Ads_table WHERE Ad_location = '" + location + "' AND Ad_category= '" + category + "'";

            try
            {
                _dbConn.Open();
                OleDbCommand cmd = new OleDbCommand(query, _dbConn);
                OleDbDataReader reader = cmd.ExecuteReader();
                listOfAds = new List<Ad>();
                while (reader.Read())
                {
                    int qNumber;
                    int.TryParse(reader.GetValue(0).ToString(), out qNumber);
                    string qCategory = reader.GetString(1);
                    string qLocation = reader.GetString(2);
                    string qAdmin = reader.GetString(3);


                    Ad newAdd = new Ad(qNumber, qCategory, qLocation, qAdmin);
                    listOfAds.Add(newAdd);
                }


            }
            catch (Exception)
            {
                throw new Exception(connectionError);
            }
            finally
            {
                _dbConn.Close();
            }

            return listOfAds;
        }

        private void voidQueryToDB(string query)
        {
            try
            {
                _dbConn.Open();
                OleDbCommand cmd = new OleDbCommand(query, _dbConn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("פרמטרים לא נכונים. אנא נסה שוב");


            }
            finally
            {
                _dbConn.Close();
            }
        }



    }
}
