using Microsoft.AspNetCore.Identity;

namespace ButlerApp.Models
{
    public class AppUser :IdentityUser
    {
      //  public string Id { get;set; }
        public string Name { get;set; }
        public string Email { get;set; }

        public string PhoneNumber { get;set; }
        public Address Address { get;set; } 
        public ICollection<Butler> Butlers { get; set; }    

    }
}
