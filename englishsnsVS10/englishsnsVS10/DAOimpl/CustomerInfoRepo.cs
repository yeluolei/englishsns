﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using englishsnsVS10.datacontext;
using englishsnsVS10.Models;
using englishsnsVS10.SystemInterfaces;

namespace englishsnsVS10.DAOimpl
{
    public class CustomerInfoRepo : ICustomerInfoRepo
    {
        private CustomerInfoDataContext db = new CustomerInfoDataContext();

        public IQueryable<user> FindAllCustomer()
        {
            return db.users;
        }

        //
        //public IQueryable<user> GetCustomer(string account)
        //{   
        //    return from user in db.users
        //           where user.username == account
        //           select user;
        //}//just for admin
        //

        public user GetCustomer(string username)
        {
            return db.users.SingleOrDefault(d => d.username == username);
        }//not for now

        public user GetCustomer(int id)
        {
            return db.users.SingleOrDefault(d => d.id == id);
        }//not for now


        public void AddCustomer(user user)
        {
            //user
            db.users.InsertOnSubmit(user);
        }//just for admin

        public void DelelteCustomer(user user)
        {
            db.users.DeleteOnSubmit(user);
        }//just for admin

        public void AddComment(comment c,user  u)
        {
            u.comments.Add(c);
        }

        public void addshare(ShareModels share)
        {

        }

        public void AddWordsbook(wordsbook wb)
        {
            db.wordsbooks.InsertOnSubmit(wb);
        }

        public IQueryable<CommentModels> getcoments(String username)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<comment> getcoments(int shareId)
        {
            return from c in db.comments
                   where c.shareid == shareId
                   select c;
        }

        public IQueryable<CommentModels> getcoments()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<wordsbook> GetWordsBook(int userid)
        {
            return from wb in db.wordsbooks
                   where wb.userid == userid
                   select wb;
        }
        public IQueryable<share> getshares(int userId)
        {
            return from s in db.shares
                   where s.userid == userId
                   select s;
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

        //public IQueryable<UserModels> getfollowers(int userId)
        //{
        //    throw new System.NotImplementedException();
        //}

        public IQueryable<follower> GetFollowedPeople(user customer)
        {
            return from follow in db.followers
                   where follow.follower1 == customer.id
                   select follow;
        }
        public void AddFollower(string userid, string followerId)
        {
            var temp = GetCustomer(followerId);
            var temp2 = GetCustomer(userid);
            follower followerInstance = new follower();
            followerInstance.follower1 = temp.id;
            followerInstance.userid = temp2.id;
            db.followers.InsertOnSubmit(followerInstance);
        }

        public void AddShare(user u, share s)
        {
            u.shares.Add(s);
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