using EnvironmentRepository.Models.BaseModels;

namespace EnvironmentRepository.Models.Musteri
{
    public class MusteriKaynak : SirketBoundBase
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public bool Varsayilan { get; set; }
    }
}
