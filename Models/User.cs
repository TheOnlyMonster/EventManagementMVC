using Microsoft.AspNetCore.Identity;

namespace EventManagementWebApp.Models
{
    public class User : IdentityUser<int>
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime DateJoined { get; set; }
        
    }

}
