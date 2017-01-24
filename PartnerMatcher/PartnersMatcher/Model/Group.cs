using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Model
{
    class Group
    {
        private Ad ad;
        private Admin admin;
        private List<User> users;
        private List<Request> requests;
        private string content;

        public Group()
        {
            users = new List<User>();
            requests = new List<Request>();
        }

        public Group(Ad ad, Admin admin, string content)
        {
            this.ad = ad;
            this.admin = admin;
            this.content = content;
            users = new List<User>();
            requests = new List<Request>();
        }

        public Group(Ad ad, Admin admin, string content, List<User> users, List<Request> requests)
        {
            this.ad = ad;
            this.admin = admin;
            this.content = content;
            this.users = users;
            this.requests = requests;
        }

        public Ad Ad { get { return ad; } set { ad = value; } }

        public Admin Admin {  get { return admin; } set { admin = value; } }

        public List<User> Users { get { return users; } set { users = value; } }

        public List<Request> Request { get { return requests; } set { requests = value; } }

        public void addUser(User user)
        {
            users.Add(user);
        }

        public void addRequest(Request request)
        {
            requests.Add(request);
        }

        public void removeUser(User user)
        {
            users.Remove(user);
        }

        public void removeRequest(Request request)
        {
            requests.Remove(request);
        }
        
    }
}
