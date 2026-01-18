using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoListDemo.Models
{
    /// <summary>
    /// Todo POCO class
    /// </summary>
    public class TodT01
    {
        /// <summary>
        /// Id of todo
        /// </summary>
        public int T01F01 { get; set; }

        /// <summary>
        /// Title of todo
        /// </summary>
        public string T01F02 { get; set; }

        /// <summary>
        /// IsCompleted of todo
        /// </summary>
        public bool T01F03 { get; set; }

        /// <summary>
        /// UserId of todo owner
        /// </summary>
        public int T01F04 { get; set; }
    }
}