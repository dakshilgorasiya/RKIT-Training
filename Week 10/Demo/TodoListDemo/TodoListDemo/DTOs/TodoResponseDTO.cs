using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoListDemo.DTOs
{
    /// <summary>
    /// A response DTO to send securing sensitive information
    /// </summary>
    public class TodoResponseDTO
    {
        /// <summary>
        /// Id of todo
        /// </summary>
        public int TodoId { get; set; }
        /// <summary>
        /// Title of todo
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Is todo completed
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}