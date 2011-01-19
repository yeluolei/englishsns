using System;

namespace englishsnsVS10.SystemInterfaces
{
    interface ICustomerInfoRepo
    {
        void AddComment(englishsnsVS10.datacontext.comment c, englishsnsVS10.datacontext.user u);
        void AddCustomer(englishsnsVS10.datacontext.user user);
        void AddFollower(string userid, string followerId);
        void AddShare(englishsnsVS10.datacontext.user u, englishsnsVS10.datacontext.share s);
        void addshare(englishsnsVS10.Models.ShareModels share);
        void AddWordsbook(englishsnsVS10.datacontext.wordsbook wb);
        void DelelteCustomer(englishsnsVS10.datacontext.user user);
        System.Linq.IQueryable<englishsnsVS10.datacontext.user> FindAllCustomer();
        System.Linq.IQueryable<englishsnsVS10.Models.CommentModels> getcoments();
        System.Linq.IQueryable<englishsnsVS10.datacontext.comment> getcoments(int shareId);
        System.Linq.IQueryable<englishsnsVS10.Models.CommentModels> getcoments(string username);
        englishsnsVS10.datacontext.user GetCustomer(int id);
        englishsnsVS10.datacontext.user GetCustomer(string username);
        System.Linq.IQueryable<englishsnsVS10.datacontext.follower> GetFollowedPeople(englishsnsVS10.datacontext.user customer);
        System.Linq.IQueryable<englishsnsVS10.datacontext.share> getshares(int userId);
        System.Linq.IQueryable<englishsnsVS10.datacontext.wordsbook> GetWordsBook(int userid);
        void save();
    }
}
