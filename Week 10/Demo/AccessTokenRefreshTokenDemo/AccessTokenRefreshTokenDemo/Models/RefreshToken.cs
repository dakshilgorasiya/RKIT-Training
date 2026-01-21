using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessTokenRefreshTokenDemo.Models
{
    [Alias("ARTT02")]
    public class RefreshToken
    {
        [Alias("T02F01")]
        public int Id { get; set; }

        [Alias("T02F02")]
        public int UserId { get; set; }

        [Alias("T02F03")]
        public string Token { get; set; }

        [Alias("T02F04")]
        public DateTime ExpiresAt { get; set; }

        [Alias("T02F05")]
        public DateTime CreatedAt { get; set; }

        [Alias("T02F06")]
        public bool IsRevoked { get; set; }
    }
}