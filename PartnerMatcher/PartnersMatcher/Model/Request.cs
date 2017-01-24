using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnersMatcher.Model
{
    public class Request
    {
        private User user;
        private string groupId;

        public Request() { }

        public Request(User user, string groupId)
        {
            this.user = user;
            this.groupId = groupId;
        }

        public User User { get { return user; } set { user = value; } }

        public string GroupId { get { return groupId; } set { groupId = value; } }
    }
}
