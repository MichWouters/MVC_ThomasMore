using Microsoft.AspNetCore.Identity;

namespace MVC_ThomasMore.Data.Entities
{
    public class CustomUser: IdentityUser
    {
        [PersonalData]
        public string  Naam { get; set; }

        [PersonalData]
        public string Adres { get; set; }
    }
}
