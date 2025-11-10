using EnvironmentRepository.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentRepository.Models.Musteri
{
    public class KontakKarar : SirketBoundBase
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public bool Varsayilan { get; set; }
    }
}
