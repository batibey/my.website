using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace my.website.Entities
{
    public class Users : IdentityUser
    {
        public string UserId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Email { get; set; }
        public string? Password { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string? Firstname { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Lastname { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? City { get; set; }
        [Column(TypeName = "nvarchar(400)")]
        public string? Address { get; set; }
        public int? Age { get; set; }
    }
}
