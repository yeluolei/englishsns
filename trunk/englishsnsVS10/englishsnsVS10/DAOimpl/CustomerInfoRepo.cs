﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using englishsnsVS10.datacontext;
using englishsnsVS10.Models;

namespace englishsnsVS10.DAOimpl
{
    public class CustomerInfoRepo
    {
        private CustomerInfoDataContext db = new CustomerInfoDataContext();

        public IQueryable<user> GetCustomer(string account)
        {
           
            return from user in db.users
                   where user.username == account
                   select user;
        }

        public void AddCustomer(user user)
        {
            db.users.InsertOnSubmit(user);
        }
        public void addcoments(CommentModels comment)
        {

        }
        public void addshare(ShareModels share)
        {

        }

        public IQueryable<CommentModels> getcoments(String username)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CommentModels> getcoments(int shareId)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CommentModels> getcoments()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ShareModels> getshares(int userId)
        {
            throw new System.NotImplementedException();
        }

//         /// <summary>
//         /// 这里只返回一个
//         /// </summary>
//         /// <param name="shareId"></param>
//         /// <returns></returns>
//         public IQueryable<ShareModels> getshares(int shareId)
//         {
//             throw new System.NotImplementedException();
//         }

        public IQueryable<UserModels> getfollowers(int userId)
        {
            throw new System.NotImplementedException();
        }

        

        /// <summary>
        /// Save data to the database
        /// </summary>
        public void save()
        {
            db.SubmitChanges();
        }
    }
}