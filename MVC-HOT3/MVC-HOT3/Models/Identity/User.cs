using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace MVC_HOT3.Models.Identity
{
    public class User : IdentityUser
    {
        [NotMapped]
        public IList<String> RoleNames { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;


    }
}

