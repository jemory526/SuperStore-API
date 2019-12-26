using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperStore_API.Web.Models
{
    // 'REQUEST MODEL' Holds incoming data from client(via PUT or POST)
    // also has validation attributes
    public class UsersCreateRequest
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}