using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperStore_API.Web.Models
{

    // 'DOMAIN MODEL' Used to hold data that comes from database and
    // sent back to the client
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public DateTime DateModified { get; set; }
        public  DateTime DateCreated { get; set; }
    }
}