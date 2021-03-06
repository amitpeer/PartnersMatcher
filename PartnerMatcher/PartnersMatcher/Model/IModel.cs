﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartnersMatcher.Controller;

namespace PartnersMatcher.Model
{
    interface IModel
    {
        void setController(IController controller);

        bool signUp(string email, string firstName, string lastName, string city, string password, int smokes, int religious, int animalLover);

        User login(string email, string pass);

        List<Ad> getAdsByLocationAndCategory(string location, string category);

        void createNewGroup(string category, string location, string title, string adContent,string groupContent);

        Group getGroupById(int id);

        User getUserByEmail(string email);

        void acceptUserToGroup(string email, int groupId);

        void addRequestForGroup(int adIdd);
        void declineUserToGroup(string email, int groupId);
    }
}
