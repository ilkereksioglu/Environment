using EnvironmentRepository.Models.BaseModels;
using EnvironmentRepository.Models.Config;

namespace EnvironmentRepository.Models.Musteri
{
    public class AdresTip : SirketBoundBase
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public bool Varsayilan { get; set; }
    }
}
