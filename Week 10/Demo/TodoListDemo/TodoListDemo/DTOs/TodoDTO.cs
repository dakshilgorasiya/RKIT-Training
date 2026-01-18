using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoListDemo.DTOs
{
    /// <summary>
    /// A DTO to get information about todo from user
    /// </summary>
    public class TodoDTO
    {
        /// <summary>
        /// Title of todo
        /// </summary>
        public string Title { get; set; }
    }
}