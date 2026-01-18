using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoListDemo.Models
{
    /// <summary>
    /// A POCO class for User
    /// </summary>
    public class TodT02
    {
        /// <summary>
        /// Id of user  
        /// </summary>
        public int T02F01 { get; set; }

        /// <summary>
        /// Username of user
        /// </summary>
        public string T02F02 { get; set; }

        /// <summary>
        /// Password hash of user
        /// </summary>
        public string T02F03 { get; set; }
    }
}