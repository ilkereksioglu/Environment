using EnvironmentRepository.Enums;
using EnvironmentRepository.Models.BaseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnvironmentRepository.Models.Musteri
{
    public class Musteri : SirketBoundBase
    {
        public int Id { get; set; }
        public string Kod { get; set; }
        public string Ad { get; set; }
        public string? Unvan { get; set; }
        public string? Ekip { get; set; }
        public string? Aciklama { get; set; }
        public bool TakipDurumu { get; set; }
        public string Telefon { get; set; }
        public string? Telefon2 { get; set; }
        public string? Faks { get; set; }
        public string CepTelefonu { get; set; }
        public string Email { get; set; }
        public string? Email2 { get; set; }
        public string? VergiDairesi { get; set; }
        public int? VergiNo { get; set; }
        public decimal? Bakiye { get; set; }
        public decimal? Iskonto { get; set; }
        public string? WebAdres { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime Created { get; set; }
        public MusteriRiskDurumu RiskDurumu { get; set; }
        public Status Status { get; set; }
        public Adres? Adres { get; set; }
        public int? AdresId { get; set; }
        public int? TipId { get; set; }
        public MusteriTip Tip { get; set; }
        public int? KategoriId { get; set; }
        public MusteriKategori? Kategori { get; set; }
        public int? KaynakId { get; set; }
        public MusteriKaynak? Kaynak { get; set; }
        public int? SektorId { get; set; }
        public MusteriSektor? Sektor { get; set; }
        [NotMapped]
        public MusteriDetay? Detay { get; set; } = new();
        [Column("Detay")]
        [JsonIgnore]
        [MaxLength(int.MaxValue)]
        public string DetailString
        {
            get { return JsonSerializer.Serialize(Detay); }
            set { Detay = JsonSerializer.Deserialize<MusteriDetay>(value); }
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

    public class SosyalMedya
    {
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string X { get; set; }
    }

    public class MusteriDetay
    {
        public SosyalMedya SosyalMedya { get; set; } = new();
    }
}
