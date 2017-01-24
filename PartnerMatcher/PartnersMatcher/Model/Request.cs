using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Model
{
    public class Request
    {
        private string user;
        private string groupId;

        public Request() { }

        public Request(string user, string groupId)
        {
            this.user = user;
            this.groupId = groupId;
        }

        public string User { get { return user; } set { user = value; } }

        public string GroupId { get { return groupId; } set { groupId = value; } }
    }
}
