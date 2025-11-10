using EnvironmentRepository.Enums;
using EnvironmentRepository.Models.BaseModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace EnvironmentRepository.Models.Musteri
{
    public class Kontak : SirketBoundBase
    {
        public string Ad { get; set; }
        public string? Aciklama { get; set; }
        public string? Departman { get; set; }
        public string? Unvan { get; set; }
        public string? DahiliTelefon { get; set; }
        public string? Telefon { get; set; }
        public string? Faks { get; set; }
        public string? Email { get; set; }
        public string? Email2 { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public KontakIliskiDurumu IliskiDurumu { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime Created { get; set; }
        public Status Status { get; set; }
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }
        public int? KararDurumuId { get; set; }
        public KontakKarar? KararDurumu { get; set; }
        [NotMapped]
        public KontakDetay? Detay { get; set; }
        [Column("Detay")]
        [JsonIgnore]
        [MaxLength(int.MaxValue)]
        public string DetailString
        {
            get { return JsonSerializer.Serialize(Detay); }
            set { Detay = JsonSerializer.Deserialize<KontakDetay>(value); }
        }
        #region Dynamic
        public int? Dyn_1 { get; set; }
        public int? Dyn_2 { get; set; }
        public int? Dyn_3 { get; set; }
        public int? Dyn_4 { get; set; }
        public string? Dyn_5 { get; set; }
        public string? Dyn_6 { get; set; }
        public string? Dyn_7 { get; set; }
        public string? Dyn_8 { get; set; }
        public decimal? Dyn_9 { get; set; }
        public decimal? Dyn_10 { get; set; }
        #endregion
    }

    public class KontakDetay
    {
    }
}
