using System.ComponentModel.DataAnnotations;

namespace MVC_ThomasMore.DTO.Gebruiker
{
    public class RegistratieDTO
    {
        [Required(ErrorMessage = "Naam is verplicht!")]
        [MaxLength(100)]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Ongeldige email!")]
        [Required(ErrorMessage = "Email is verplicht!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht!")]
        [Compare(nameof(Password), ErrorMessage = "Wachtwoorden zijn niet hezelfde")]
        public string PasswordConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }
    }
}
