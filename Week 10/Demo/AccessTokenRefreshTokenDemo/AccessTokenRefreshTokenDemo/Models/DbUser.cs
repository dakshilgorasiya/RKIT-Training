using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessTokenRefreshTokenDemo.Models
{
    [Alias("ARTT01")]
    public class DbUser
    {
        [Alias("T01F01")]
        public int Id { get; set; }

        [Alias("T01F02")]
        public string Name { get; set; }

        [Alias("T01F03")]
        public string PasswordHash { get; set; }
    }
}