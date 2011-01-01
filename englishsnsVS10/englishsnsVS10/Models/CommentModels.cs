using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using englishsnsVS10.datacontext;

namespace englishsnsVS10.Models
{
    public class CommentModels
    {
        public CommentModels(int _CommentId, String _CommentContent, DateTime _time, int _shareId, int _userId)
        {
            CommentId = _CommentId;
            CommentContent = _CommentContent;
            time = _time;
            shareId = _shareId;
            userId = _userId;
        }
        public CommentModels(IQueryable<comment> comments)
        {
            this.comments = comments;
        }

        public int CommentId { get; set; }
        public String CommentContent { get; set; }
        public DateTime time { get; set; }
        public int shareId { get; set; }
        public int userId { get; set; }
        public IQueryable<comment> comments;
    }
}