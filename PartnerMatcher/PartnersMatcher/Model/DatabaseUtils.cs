﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Model
{
    class DatabaseUtils
    {
        static readonly string localPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        private static readonly string pathToDb = localPath + @"\Data\PartnerMatcherDB.accdb";
        private OleDbConnection _dbConn;
        private readonly string connectionError;
        private readonly string dataBaseError ="פעולה נכשלה:" + "\n" + "To fix the problem, try to download the Microsoft Access Database Engine 2010 Redistributable from the link: \nhttps://www.microsoft.com/en-us/download/details.aspx?id=13255\nPlease read the readme file for more information.";


        public DatabaseUtils()
        {
            _dbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathToDb + "; Persist Security Info=False");  // defining the source of the data base, meaning connection           
            connectionError = "Connection error! try again later";
        }

        public void addUser(User user)
        {
            string email = user.Email;
            string firstName = user.FirstName;
            string lastName = user.LastName;
            string city = user.City;
            string pass = user.Pssword;
            int smokes = user.Smoke;
            int religious = user.Religious;
            int animalLover = user.AnimalLover;
            string query = "insert into Users (User_Email,User_First_Name,User_Last_Name,User_city,User_password,Smokes,Religious,Animal_Lover) values('" + email + "','" + firstName + "','" + lastName + "','" + city + "','" + pass + "','" + smokes + "','" + religious + "','" + animalLover + "')";
            if (checkIfEmailExistsInDb(email))
                throw new Exception("המשתמש כבר רשום במערכת, אנא בצע התחברות.");
            voidQueryToDB(query);   
        }
   
        public void addAd(Ad ad)
        {

            int number = ad.SerialNumber;
            string category = ad.Category;
            string location = ad.Location;
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
                throw new Exception(dataBaseError);
            }
            finally
            {
                _dbConn.Close();
            }
            return false;
        }

        public User connectUser(string email, string pass)
        {
            User user = getUserByEmail(email);
            if (user == null)
                return null;
            if (user.Pssword == "" || user.Pssword != pass)
                 throw new Exception("פרטי התחברות שגויים");
            
            return user;
        }

        internal User getUserByEmail(string email)
        {
            User user = null;
            string query = "SELECT* FROM Users WHERE User_Email = '" + email + "'";

            string qEmail = "", qFname = "", qLname = "", qCity = "", qPass = "";
            int qSmoke = 0, qReligious = 0, qAnimalLover = 0;
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
                    qSmoke = reader.GetInt32(5);
                    qReligious = reader.GetInt32(6);
                    qAnimalLover = reader.GetInt32(7);

                }
                user = new User(email, qFname, qLname, qCity, qPass, qSmoke, qReligious, qAnimalLover);
                user.Groups = getUserGroups(user.Email);
                    
            }
            catch (Exception)
            {
                throw new Exception(dataBaseError);
            }
            finally
            {
                _dbConn.Close();
            }
            return user;
        }

        internal void addRequestToGroup(int adId, string email)
        {
            string getGroupID = "SELECT group_id from Groups WHERE group_adID='" + adId + "'";
            string groupID = "";
            isQueryEmpty(getGroupID, out groupID);
            string checkRecExistQuery = "SELECT group_id from Requests WHERE user_email='" + email + "' AND group_id='" + groupID + "'";

            string answer = "";
            if(!(isQueryEmpty(checkRecExistQuery, out answer)))
                 throw new Exception("כבר ביקשת להצטרף לקבוצה זו,נא המתן לאישור");
            else
            {
                string insertRequest = "insert into Requests (group_id,user_email) values('" + groupID + "','" + email + "')";
                voidQueryToDB(insertRequest);

            }
        }

        //check if query is empty, if not get the first answer from DB to answer
        public bool isQueryEmpty(string query,out string answer)
        {
            answer = "";
            bool dbWasOpen = true;
            try
            {
                if (_dbConn.State != ConnectionState.Open)
                {
                    _dbConn.Open();
                    dbWasOpen = false;
                }
                OleDbCommand cmd = new OleDbCommand(query, _dbConn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    answer = reader.GetValue(0).ToString();
                }
                if (answer != "")  //so the recored is exist
                    return false;
                
            }
            catch
            {
                throw new Exception("בעייה בהתחברות למסד הנתונים");
            }
            finally
            {
                if (!dbWasOpen)
                    _dbConn.Close();
            }
            return true;
        }
            
        public Group getGroupByID(int id)
        {
            Group group;
            Ad groupAd=null;
            try
            {
                _dbConn.Open();
                List<Request> groupRequest = getGroupRequest(id);
                List<string> usersInGroup = getUsersForGroup(id);
                string query = "SELECT* from Groups WHERE group_id =" + id + "";
                OleDbCommand cmd = new OleDbCommand(query, _dbConn);
                string str = Convert.ToString(cmd.ExecuteScalar());
                OleDbDataReader reader = cmd.ExecuteReader();
                string groupID = ""; string groupAdID="" ; string groupTitle = "";
                string groupContent = ""; string groupAdmin = "";
                while (reader.Read())
                {
                    groupID = reader.GetValue(0).ToString();
                    groupAdID = reader.GetString(1);
                    groupAd = getGroupAd(int.Parse(groupAdID));
                    groupTitle = reader.GetString(2);
                    groupContent = reader.GetString(3);
                    groupAdmin = reader.GetString(4);
                }

                group = new Group(groupAd, groupAdmin, groupContent, groupTitle, id, usersInGroup, groupRequest);
            }
            catch (Exception)
            {

                throw new Exception("תקלה בהעלאת הקבוצה");
            }
            finally
            {
                _dbConn.Close();
            }
            return group;
        }

        private List<string> getUsersForGroup(int id)
        {
            List<string> userGroups = new List<string>();
            string query = "SELECT user_email from Groups_and_users WHERE group_id='" + id + "'";
            OleDbCommand cmd = new OleDbCommand(query, _dbConn);
            OleDbDataReader reader = cmd.ExecuteReader();
            string userEmail = "";
            while (reader.Read())
            {
                userEmail = reader.GetValue(0).ToString();
                userGroups.Add(userEmail);
            }
            return userGroups;
        }

        private Ad getGroupAd(int id)
        { 
            string query = "SELECT* from Ads_table WHERE Ad_id = " + id + "";
            OleDbCommand cmd = new OleDbCommand(query, _dbConn);
            OleDbDataReader reader = cmd.ExecuteReader();
            string adID = "";
            string adCategory = "";
            string adLocation = "";
            string adTitle = ""; string content = "";
            while (reader.Read())
            {
                adID = reader.GetValue(0).ToString();
                adCategory = reader.GetString(1);
                adLocation = reader.GetString(2);
                adTitle = reader.GetString(3);
                content= reader.GetString(4);

            }
            Ad ad = new Ad(int.Parse(adID), adCategory, adLocation, adTitle,content);
            return ad;
        }
    
        private List<Request> getGroupRequest(int id)
        {
            List<Request> allRequest = new List<Request>();
            string query = "SELECT* from Requests WHERE group_id = '" + id + "'";
            OleDbCommand cmd = new OleDbCommand(query, _dbConn);
            OleDbDataReader reader = cmd.ExecuteReader();
            string groupID = "";
            string userID = "";
            while (reader.Read())
            {
                groupID = reader.GetValue(0).ToString();
                userID = reader.GetString(1);
                allRequest.Add(new Request(userID,groupID));
            }

            return allRequest;
        }

        private List<int> getUserGroups(string email)
        {
            List<int> userGroups = new List<int>();
            string query = "SELECT group_id from Groups_and_users WHERE user_email='" + email + "'";
            OleDbCommand cmd = new OleDbCommand(query, _dbConn);
            OleDbDataReader reader = cmd.ExecuteReader();
            string groupID = "";
            while (reader.Read())
            {
                groupID = reader.GetValue(0).ToString();
                userGroups.Add(int.Parse(groupID));
            }
            return userGroups;
        }

        public List<Ad> getAdsByLocationAndCategory(string location, string category,string email)
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
                    string title = reader.GetString(3);
                    string content = reader.GetString(4);

                    if (!isUserFreindInAdGroup(email, qNumber))
                    {
                        Ad newAdd = new Ad(qNumber, qCategory, qLocation, title,content);
                        listOfAds.Add(newAdd);
                    }
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

        private bool isUserFreindInAdGroup(string email, int adId)
        {
            string getGroupID = "SELECT group_id from Groups WHERE group_adID='" + adId + "'";
            string groupID = "";
            isQueryEmpty(getGroupID, out groupID);

            string checkRecExistQuery = "SELECT group_id from Groups_and_users WHERE user_email='" + email + "' AND group_id='" + groupID + "'";

            string answer = "";
            if (isQueryEmpty(checkRecExistQuery, out answer))
                return false;
            return true;
        }

        private void voidQueryToDB(string query)
        {
            try
            {
                _dbConn.Open();

            }
            catch (Exception e)
            {
                throw new Exception(dataBaseError);
            }
            try
            {
                OleDbCommand cmd = new OleDbCommand(query, _dbConn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("בעייה בהכנסה למסד הנתונים");
            }
            finally
            {
                _dbConn.Close();
            }
        }

        public void createNewGrop(string category, string location, string title, string adContent,string groupContent, string userMail)
        {
            try
            {
                string addAdQuery = "insert into Ads_table (Ad_category,Ad_location,Ad_title,Ad_content) values('" + category + "','" + location + "','" + title + "','" + adContent + "')";
                voidQueryToDB(addAdQuery);
                OleDbCommand maxCommand = new OleDbCommand("SELECT max(Ad_id) from Ads_table", _dbConn);
                int adInseetedID = getLastinSertedId("Ads_table","Ad_id");
                string addGroupQuery = "insert into Groups (group_adID,group_title,group_content,group_adminID) values('" + adInseetedID + "','" + title + "','" + groupContent + "','" + userMail + "')";
                voidQueryToDB(addGroupQuery);
                addUserToGroup(userMail, getLastinSertedId("Groups","group_id"));
            }
            catch (Exception)
            {
                throw new Exception("הוספת ההודעה נכשלה.\n אנא וודא כי השדות שלך לא מכילים סימני פסוק מלבד סימנים הבאים: (),.:;[]");
            }
        }

        private int getLastinSertedId(string tableName, string fieldName)
        {
            Int32 adInseetedID = 0;
            try
            {
                _dbConn.Open();

            }
            catch (Exception e)
            {
                throw new Exception(dataBaseError);
            }
            try
            {
                OleDbCommand maxCommand = new OleDbCommand("SELECT max("+fieldName+") from " + tableName, _dbConn);
                adInseetedID = (Int32)maxCommand.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw new Exception("פרמטרים לא נכונים. אנא נסה שוב");
            }
            finally
            {
                _dbConn.Close();
            }
            return adInseetedID;
        }

        public void addUserToGroup(string email, int groupId)
        {
                string query = "insert into Groups_and_users (group_id,user_email) values('" + groupId + "','" + email + "')";
                voidQueryToDB(query);
                deleteRecordFromTable("Requests","group_id",groupId.ToString(),"user_email", email);
        }

        private void deleteRecordFromTable(string tableName, string fieldName, string WhereFieldEqualTo)
        {
            string query = "DELETE FROM "+ tableName+ " WHERE [" + fieldName + "] = '" + WhereFieldEqualTo + "'";
            voidQueryToDB(query);
        }

        private void deleteRecordFromTable(string tableName, string fieldName, string WhereFieldEqualTo, string fieldName2, string WhereFieldEqualTo2)
        {
            string query = "DELETE FROM " + tableName + " WHERE [" + fieldName + "] = '" + WhereFieldEqualTo + "'" +" AND ["+  fieldName2 + "] = '" + WhereFieldEqualTo2 + "'";
            voidQueryToDB(query);
        }

        internal void declineUserToGroup(string email, int groupId)
        {
            deleteRecordFromTable("Requests", "group_id", groupId.ToString(), "user_email", email);
        }
    }
}
