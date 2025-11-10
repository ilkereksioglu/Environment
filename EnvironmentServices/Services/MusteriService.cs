using EnvironmentRepository.Models.Musteri;
using EnvironmentServices.ServiceResult;
using EnvironmentRepository.Repos;
using EnvironmentRepository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using EnvironmentServices.DTO.MusteriDTO;
using EnvironmentRepository.Models.BaseModels;

namespace EnvironmentServices.Services
{
    public interface IMusteriService
    {
        Task<ServiceResult<MusteriDetailDTO>> MusteriGetir(int id);
        Task<ServiceResult<ServiceResultData<List<Musteri>>>> TumMusterileriGetir();
        Task<ServiceResult<Musteri>> MusteriEkleGuncelle(MusteriEkleGuncelleDTO model);
    }


    public class MusteriService : BaseService, IMusteriService
    {
        private readonly IMusteriRepo _musteriRepo;
        private readonly ITransaction _transaction;
        public MusteriService(IBaseRepo baseRepo, IVeriListesiRepo veriListesiRepo, IMusteriRepo musteriRepo, ITransaction transaction) : base(baseRepo, veriListesiRepo)
        {
            _musteriRepo = musteriRepo;
            _transaction = transaction;
        }

        public async Task<ServiceResult<MusteriDetailDTO>> MusteriGetir(int id)
        {
            var musteri = id > 0 
                ? (await _baseRepo.WhereSiteFilter<Musteri>()
                    .Include(x => x.Tip)
                    .Include(x => x.Kategori)
                    .Include(x => x.Sektor)
                    .Include(x => x.Adres)
                    .FirstOrDefaultAsync(x => x.Id == id)) 
                : new Musteri { };
            var musteriTipleri = _baseRepo.GetAllParallelFiltered<MusteriTip>();
            var musteriKategorileri = _baseRepo.GetAllParallelFiltered<MusteriKategori>();
            var musteriSektorleri = _baseRepo.GetAllParallelFiltered<MusteriSektor>();
            var musteriKaynaklari = _baseRepo.GetAllParallelFiltered<MusteriKaynak>();
            var adresTipleri = _baseRepo.GetAllParallelFiltered<AdresTip>();
            var veriListesi = _veriListesiRepo.VeriListesiGetir(nameof(Musteri));
            var taskList = new Task[] { musteriTipleri, musteriKategorileri, musteriSektorleri, musteriKaynaklari, adresTipleri, veriListesi };
            await Task.WhenAll(taskList);
            if (musteri == null && id > 0)
                return new ServiceResult<MusteriDetailDTO> { Data = null, ErrorMessage = "Musteri bulunamadi" };
            return new ServiceResult<MusteriDetailDTO> { 
                Data = new MusteriDetailDTO { 
                    Musteri = id > 0 ? new(musteri) : new(), 
                    Adres = id > 0 && musteri.Adres != null ? new(musteri.Adres) : new(),
                    VeriListesi = veriListesi.Result,
                    MusteriKategorileri = musteriKategorileri.Result,
                    MusteriSektorleri = musteriSektorleri.Result,
                    MusteriKaynaklari = musteriKaynaklari.Result,
                    MusteriTipleri = musteriTipleri.Result }, Succeeded = true 
            };
        }

        public async Task<ServiceResult<ServiceResultData<List<Musteri>>>> TumMusterileriGetir()
        {
            var musteriler = await _baseRepo.WhereSiteFilter<Musteri>()
                .Include(x => x.Tip)
                .Include(x => x.Kategori)
                .Include(x => x.Sektor)
                .ToListAsync();
            var veriListesi = await _veriListesiRepo.VeriListesiGetir(nameof(Musteri));
            if (musteriler.Count() == 0)
                return new ServiceResult<ServiceResultData<List<Musteri>>> { Data = null, ErrorMessage = "Hic musteri bulunamadi" };
            return new ServiceResult<ServiceResultData<List<Musteri>>> { Data = new ServiceResultData<List<Musteri>> { MainData = musteriler, FieldData = veriListesi }, Succeeded = true };
        }

        public async Task<ServiceResult<Musteri>> MusteriEkleGuncelle(MusteriEkleGuncelleDTO model)
        {         
            try
            {
                var musteri = model.Musteri.ToMusteri();
                musteri.Adres = model.Adres.ToAdres();
                var consistenyResult = await MusteriConsistencyCheck(musteri);
                if (!consistenyResult.Succeeded)
                    return consistenyResult;
                if (musteri.Id == 0)
                    await _baseRepo.AddAsync<Musteri>(musteri);
                else
                    _baseRepo.Update<Musteri>(musteri);

                await _transaction.SaveChangesAsync();
                return new ServiceResult<Musteri> { Data = null, Succeeded = true };
            }
            catch(Exception e)
            {
                return new ServiceResult<Musteri> { Error = e, ErrorMessage = e.Message };
            }
        }

        private async Task<ServiceResult<Musteri>> MusteriConsistencyCheck(Musteri musteri)
        {
            var kategori = musteri.KategoriId > 0 ? (_baseRepo.SingleOrDefaultParallelFiltered<MusteriKategori>(x => x.Id == musteri.KategoriId)) : Task.FromResult(new MusteriKategori());
            var tip = musteri.KategoriId > 0 ? (_baseRepo.SingleOrDefaultParallelFiltered<MusteriTip>(x => x.Id == musteri.TipId)) : Task.FromResult(new MusteriTip());
            var sektor = musteri.SektorId > 0 ? (_baseRepo.SingleOrDefaultParallelFiltered<MusteriSektor>(x => x.Id == musteri.SektorId)) : Task.FromResult(new MusteriSektor());
            var kaynak = musteri.KaynakId > 0 ? (_baseRepo.SingleOrDefaultParallelFiltered<MusteriKaynak>(x => x.Id == musteri.KategoriId)) : Task.FromResult(new MusteriKaynak());
            //var kaynak = musteri.KaynakId > 0 ? (_baseRepo.SingleOrDefaultAsync<AdresTip>(x => x. == musteri.)) : Task.FromResult(new MusteriKaynak());
            var taskList = new Task<SirketBoundBase>[] { GeneralizeSirketBoundTask(kategori), GeneralizeSirketBoundTask(sektor), GeneralizeSirketBoundTask(kaynak), GeneralizeSirketBoundTask(tip) };
            var results = await Task.WhenAll<SirketBoundBase>(taskList);
            if(results.Any(x => x == null))
            {
                var errorMessage = kategori.Result == null ? "Kategori bulunamamistir. " : "";
                errorMessage += tip.Result == null ? "Tip bulunamamistir. " : "";
                errorMessage += sektor.Result == null ? "Sektor bulunamamistir. " : "";
                errorMessage += kaynak.Result == null ? "Kaynak bulunamamistir." : "";
                return new ServiceResult<Musteri> { Succeeded = false, ErrorMessage = errorMessage };
            }

            return new ServiceResult<Musteri> { Succeeded = true };
        }
    }
}
