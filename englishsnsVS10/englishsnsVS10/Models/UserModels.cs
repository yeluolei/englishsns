using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace englishsnsVS10.Models
{
    public class UserModels
    {
        public UserModels(int _userId , String _username,String _name)
        {
            userId = _userId;
            username = _username;
            name = _name;
        }

        public int userId { get; private set; }
        public string username { get; private set; }
        public string name { get; set; }
    }
}