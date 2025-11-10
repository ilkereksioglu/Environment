using System.ComponentModel.DataAnnotations;

namespace EnvironmentAPI.Models.Kullanici
{
    public class KayitOlModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string KullaniciAdi { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }
        [MinLength(6)]
        [MaxLength(20)]
        [Required]
        public string PasswordDogrulama { get; set; }
        [Required]
        public List<int> Sirketler { get; set; }
    }
}
