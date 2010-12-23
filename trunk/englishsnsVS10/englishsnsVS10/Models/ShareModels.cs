using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace englishsnsVS10.Models
{
    public class ShareModels
    {
        public ShareModels(int _shareId,String _shareContent,DateTime _time,int _userId)
        {
            shareId = _shareId;
            shareContent = _shareContent;
            time = _time;
            userId = _userId;
        }
        public int shareId { get; set; }
        public String shareContent { get; set; }
        public DateTime time { get; private set; }
        public int userId { get; set; }
    }
}