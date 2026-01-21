using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessTokenRefreshTokenDemo.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}