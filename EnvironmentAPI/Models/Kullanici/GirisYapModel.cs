using System.ComponentModel.DataAnnotations;

namespace EnvironmentAPI.Models.Kullanici
{
    public class GirisYapModel
    {
        [EmailAddress]
        public string? Email { get; set; }
        [MinLength(4)]
        [MaxLength(20)]
        public string KullaniciAdi { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
