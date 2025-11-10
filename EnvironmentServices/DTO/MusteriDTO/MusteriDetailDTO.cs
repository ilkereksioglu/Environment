using EnvironmentRepository.Models.BaseModels;
using EnvironmentRepository.Models.Dynamic;
using EnvironmentRepository.Models.Musteri;

namespace EnvironmentServices.DTO.MusteriDTO
{
    public class MusteriDetailDTO
    {
        public MusteriModel Musteri { get; set; }
        public AdresModel Adres { get; set; }
        public List<MusteriTip> MusteriTipleri { get; set; }
        public List<MusteriKategori> MusteriKategorileri { get; set; }
        public List<MusteriSektor> MusteriSektorleri { get; set; }
        public List<MusteriKaynak> MusteriKaynaklari { get; set; }
        public List<AdresTip> AdresTipleri { get; set; }
        public List<VeriListesi> VeriListesi { get; set; }
    }

    public class MusteriEkleGuncelleDTO
    {
        public MusteriModel Musteri { get; set; }
        public AdresModel Adres { get; set; }
    }

    public class MusteriModel
    {
        public MusteriModel(){}
        public MusteriModel(Musteri musteri)
        {
            Id = musteri.Id;
            Kod = musteri.Kod;
            Ad = musteri.Ad;
            Unvan = musteri.Unvan;
            Ekip = musteri.Ekip;
            Aciklama = musteri.Aciklama;
            TakipDurumu = musteri.TakipDurumu;
            Telefon = musteri.Telefon;
            Telefon2 = musteri.Telefon2;
            Faks = musteri.Faks;
            CepTelefonu = musteri.CepTelefonu;
            Email = musteri.Email;
            Email2 = musteri.Email2;
            VergiDairesi = musteri.VergiDairesi;
            VergiNo = musteri.VergiNo;
            Bakiye = musteri.Bakiye;
            Iskonto = musteri.Iskonto;
            WebAdres = musteri.WebAdres;
            TipId = musteri.TipId;
            KategoriId = musteri.KategoriId;
            KaynakId = musteri.KaynakId;
            SektorId = musteri.SektorId;
            Detay = musteri.Detay;
            Dyn_1 = musteri.Dyn_1;
            Dyn_2 = musteri.Dyn_2;
            Dyn_3 = musteri.Dyn_3;
            Dyn_4 = musteri.Dyn_4;
            Dyn_5 = musteri.Dyn_5;
            Dyn_6 = musteri.Dyn_6;
            Dyn_7 = musteri.Dyn_7;
            Dyn_8 = musteri.Dyn_8;
            Dyn_9 = musteri.Dyn_9;
            Dyn_10 = musteri.Dyn_10;
        }
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
        public int? TipId { get; set; }
        public int? KategoriId { get; set; }
        public int? KaynakId { get; set; }
        public int? SektorId { get; set; }
        public MusteriDetay? Detay { get; set; } = new();
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

        public Musteri ToMusteri()
        {
            return new Musteri
            {
                Id = Id,
                Kod = Kod,
                Ad = Ad,
                Unvan = Unvan,
                Ekip = Ekip,
                Aciklama = Aciklama,
                TakipDurumu = TakipDurumu,
                Telefon = Telefon,
                Telefon2 = Telefon2,
                Faks = Faks,
                CepTelefonu = CepTelefonu,
                Email = Email,
                Email2 = Email2,
                VergiDairesi = VergiDairesi,
                VergiNo = VergiNo,
                Bakiye = Bakiye,
                Iskonto = Iskonto,
                WebAdres = WebAdres,
                TipId = TipId,
                KategoriId = KategoriId,
                KaynakId = KaynakId,
                SektorId = SektorId,
                Detay = Detay,
                Dyn_1 = Dyn_1,
                Dyn_2 = Dyn_2,
                Dyn_3 = Dyn_3,
                Dyn_4 = Dyn_4,
                Dyn_5 = Dyn_5,
                Dyn_6 = Dyn_6,
                Dyn_7 = Dyn_7,
                Dyn_8 = Dyn_8,
                Dyn_9 = Dyn_9,
                Dyn_10 = Dyn_10
            };
        }
    }

    public class SosyalMedyaModel
    {
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string X { get; set; }
    }

    public class MusteriDetayModel
    {
        public SosyalMedyaModel SosyalMedya { get; set; } = new();
    }

    public class AdresModel
    {
        public AdresModel() { }
        public AdresModel(Adres adres)
        {
            Id = adres.Id;
            AdresTipId = adres.AdresTipId;
            Satir1 = adres.Satir1;
            Satir2 = adres.Satir2;
            UlkeId = adres.UlkeId;
            Sehir = adres.Sehir;
            Ilce = adres.Ilce;
            PostaKodu = adres.PostaKodu;
            BolgeKodu = adres.BolgeKodu;
        }
        public int Id { get; set; }
        public int? AdresTipId { get; set; }
        public string Satir1 { get; set; }
        public string? Satir2 { get; set; }
        public int? UlkeId { get; set; } = null;
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public int PostaKodu { get; set; }
        public int BolgeKodu { get; set; }

        public Adres ToAdres()
        {
            return new Adres
            {
                Id = Id,
                AdresTipId = AdresTipId,
                Satir1 = Satir1,
                Satir2 = Satir2,
                UlkeId = UlkeId,
                Sehir = Sehir,
                Ilce = Ilce,
                PostaKodu = PostaKodu,
                BolgeKodu = BolgeKodu
            };
        }
    }
}
