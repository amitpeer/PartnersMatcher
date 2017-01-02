using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher
{
    class DatabaseUtils
    {
        OleDbConnection _dbConn;


        public DatabaseUtils(string pathToDataBase)
        {
            _dbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\FacesDatabase.accdb;
                                        Persist Security Info=False");  // defining the source of the data base, meaning connection

        }
         //hello

        public void addUser(User user)
        {
            _dbConn.Open();
        }

        public void addAd(Ad ad)
        {


        }

        public User connectUser(string email, string pass)
        {
            User user = new User();

            return user;
        }

        public List<Ad> getAdsByLocationAndCategory(string location, string category)
        {
            List<Ad> listOfAds = new List<Ad>();

            return listOfAds;


        }

    }
}
