using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoListDemo.DTOs
{
    /// <summary>
    /// A dto to create user
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// Username of user
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password of user
        /// </summary>
        public string Password { get; set; }
    }
}