using EnvironmentRepository.Models.BaseModels;
using EnvironmentRepository.Models.Config;

namespace EnvironmentRepository.Models.Musteri
{
    public class Kategori : SirketBoundBase
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public bool Varsayilan { get; set; }
    }
}
