using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperStore_API.Web.Models
{
    public class UsersUpdateRequest : UsersCreateRequest
    {
        [Required]
        public int? Id { get; set; } // "int?" = nullable int
    }
}