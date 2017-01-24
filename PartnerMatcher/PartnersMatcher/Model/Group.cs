using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Model
{
    public class Group
    {
        private Ad ad;
        private string admin;
        private List<string> users;
        private List<Request> requests;
        private string content;
        private string title;
        private int id;

        public Group()
        {
            users = new List<string>();
            requests = new List<Request>();
        }

        public Group(Ad ad, string admin, string content, string title, int id)
        {
            this.ad = ad;
            this.admin = admin;
            this.content = content;
            this.title = title;
            this.id = id;
            users = new List<string>();
            requests = new List<Request>();
        }

        public Group(Ad ad, string admin, string content, List<string> users, List<Request> requests)
        {
            this.ad = ad;
            this.admin = admin;
            this.content = content;
            this.users = users;
            this.requests = requests;
        }

        public Ad Ad { get { return ad; } set { ad = value; } }

        public string Admin {  get { return admin; } set { admin = value; } }

        public List<string> Users { get { return users; } set { users = value; } }

        public List<Request> Request { get { return requests; } set { requests = value; } }

        public string Title { get { return title; } set { title = value; } }     

        public int Id { get { return id; } set { id = value; } }

        public string Content { get { return content; } set { content = value; } }
    }
}
