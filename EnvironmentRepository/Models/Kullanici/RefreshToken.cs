using EnvironmentRepository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentRepository.Models.Kullanici
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public string Key { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
