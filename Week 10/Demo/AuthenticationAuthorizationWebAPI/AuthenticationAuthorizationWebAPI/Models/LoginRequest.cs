using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationAuthorizationWebAPI.Models
{
    /// <summary>
    /// A DTO represeting data need to login
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Username of user
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password of user
        /// </summary>
        public string Password { get; set; }
    }
}