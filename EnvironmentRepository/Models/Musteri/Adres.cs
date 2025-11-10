using EnvironmentRepository.Models.BaseModels;

namespace EnvironmentRepository.Models.Musteri
{
    public class Adres : SirketBoundBase
    {
        public int Id { get; set; }
        public AdresTip? Tip { get; set; }
        public int? AdresTipId { get; set; }
        public string Satir1 { get; set; }
        public string? Satir2 { get; set; }
        public Ulke? Ulke { get; set; }
        public int? UlkeId { get; set; } = null;
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public int PostaKodu { get; set; }
        public int BolgeKodu { get; set; }
    }
}
