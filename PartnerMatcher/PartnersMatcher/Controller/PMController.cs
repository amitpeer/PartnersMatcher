﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartnersMatcher.Model;
using PartnersMatcher.View;

namespace PartnersMatcher.Controller
{
    class PMController:IController
    {
        private IView view;
        private IModel model;
        public PMController(IView view,IModel model)
        {
            this.view = view;
            this.model = model;
        }

        public bool signUp(string email, string firstName, string lastName, string city, string password,int smokes, int religious, int animalLover)
        {
            return model.signUp(email,firstName,lastName,city,password, smokes, religious, animalLover);
        }

        public void showMessage(string text)
        {
            view.showMessage(text);
        }

        public User login(string email, string pass)
        {
            return model.login(email, pass);
        }

        public List<Ad> getAdsByLocationAndCategory(string location, string category)
        {

            return model.getAdsByLocationAndCategory(location, category);
        }

        public void createNewGroup(string category, string location, string title, string adContent, string groupContent)
        {
            model.createNewGroup(category, location, title, adContent, groupContent);
        }

        public Group getGroupById(int id)
        {
            return model.getGroupById(id);
        }

        public User getUserByEmail(string email)
        {
            return model.getUserByEmail(email);
        }

        public void acceptUserToGroup(string email, int groupId)
        {
            model.acceptUserToGroup(email, groupId);
            
            
            
        }

        public void declineUserToGroup(string email, int groupId)
        {
            model.declineUserToGroup(email, groupId);
        }

        public void addRequest(int adId)
        {
            model.addRequestForGroup(adId);
        }

        public bool isUserInGroup(int adId)
        {
            throw new NotImplementedException();
        }
    }
}
