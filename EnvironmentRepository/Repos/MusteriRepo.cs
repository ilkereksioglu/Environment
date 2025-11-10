using EnvironmentRepository.Database;
using EnvironmentRepository.Models.BaseModels;
using EnvironmentRepository.Models.Musteri;
using Microsoft.EntityFrameworkCore;

namespace EnvironmentRepository.Repos
{
    public interface IMusteriRepo
    {
        Task<Musteri> MusteriGuncelle(Musteri musteri);
        Task<Musteri> MusteriEkle(Musteri musteri);
    }

    public class MusteriRepo : BaseRepo, IMusteriRepo
    {
        public MusteriRepo(
            EnvironmentDbContext environmentDb, 
            SiteControlModel siteControlModel, 
            IDbContextFactory<EnvironmentDbContext> contextFactory) : base(environmentDb, siteControlModel, contextFactory) { }

        public Task<Musteri> MusteriEkle(Musteri musteri)
        {
            throw new NotImplementedException();
        }

        public Task<Musteri> MusteriGuncelle(Musteri musteri)
        {
            throw new NotImplementedException();
        }
    }
}
