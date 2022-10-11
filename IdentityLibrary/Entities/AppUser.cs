using Microsoft.AspNetCore.Identity;

namespace IdentityLibrary.Entities
{
    public class AppUser:IdentityUser<int> //int means primary key type
    {
        //We can add custom columns here
        public string Gender { get; set; }
    }
}
