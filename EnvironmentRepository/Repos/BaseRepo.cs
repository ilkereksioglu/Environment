using EnvironmentRepository.Database;
using EnvironmentRepository.Models.BaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EnvironmentRepository.Repos
{
    public interface IBaseRepo 
    {
        public IQueryable<T> WhereSiteFilter<T>() where T : SirketBoundBase;
        Task<T> AddFiltered<T>(T data) where T : SirketBoundBase;
        IQueryable<T> Where<T>(Expression<Func<T, bool>> func) where T : class;
        IQueryable<T> WhereFiltered<T>(Expression<Func<T, bool>> func) where T : SirketBoundBase;
        Task<List<T>> GetAllAsync<T>() where T : class;
        Task<List<T>> GetAllAsyncFiltered<T>() where T : SirketBoundBase;
        Task<T> FirstAsync<T>(Expression<Func<T, bool>> func) where T : class;
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> func) where T : class;
        Task<T> SingleAsync<T>(Expression<Func<T, bool>> func) where T : class;
        Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> func) where T : class;
        Task AddAsync<T>(T data) where T : class;
        void Update<T>(T data) where T : class;
        Task<SirketBoundBase> GeneralizeSirketBoundTask<TDerived>(Task<TDerived> task) where TDerived : SirketBoundBase;
        Task<List<T>> GetAllParallelFiltered<T>() where T : SirketBoundBase;
        Task<T> SingleOrDefaultParallelFiltered<T>(Expression<Func<T, bool>> func) where T : SirketBoundBase;
    }

    public class BaseRepo : IBaseRepo
    {
        protected readonly EnvironmentDbContext _environmentDb;
        protected readonly SiteControlModel _siteControlModel;
        private readonly IDbContextFactory<EnvironmentDbContext> _contextFactory;

        public BaseRepo(EnvironmentDbContext environmentDb, SiteControlModel siteControlModel, IDbContextFactory<EnvironmentDbContext> contextFactory)
        {
            _environmentDb = environmentDb;
            _siteControlModel = siteControlModel;
            _contextFactory = contextFactory;
        }

        private Expression<Func<T, bool>> GenerateSiteFilterExpression<T>() where T : SirketBoundBase
        {
            return x => (_siteControlModel.IsSuperAdmin || _siteControlModel.SirketListesi.Contains(x.SirketId.GetValueOrDefault()));
        }

        public IQueryable<T> WhereSiteFilter<T>() where T : SirketBoundBase
        {
            return _environmentDb.Set<T>().Where(GenerateSiteFilterExpression<T>());
        }

        public async Task<T> AddFiltered<T>(T data) where T : SirketBoundBase
        {
            await _environmentDb.Set<T>().AddAsync(data);
            return data;
        }

        public IQueryable<T> Where<T>(Expression<Func<T, bool>> func) where T : class => _environmentDb.Set<T>().Where(func);
        public IQueryable<T> WhereFiltered<T>(Expression<Func<T, bool>> func) where T : SirketBoundBase => _environmentDb.Set<T>().Where(GenerateSiteFilterExpression<T>()).Where(func);
        public async Task<List<T>> GetAllAsync<T>() where T : class => await _environmentDb.Set<T>().ToListAsync();
        public async Task<List<T>> GetAllAsyncFiltered<T>() where T : SirketBoundBase => await _environmentDb.Set<T>().Where(GenerateSiteFilterExpression<T>()).ToListAsync();
        public async Task<T> FirstAsync<T>(Expression<Func<T, bool>> func) where T : class => await _environmentDb.Set<T>().FirstAsync(func);
        public async Task<T> FirstAsyncFiltered<T>(Expression<Func<T, bool>> func) where T : SirketBoundBase => await _environmentDb.Set<T>().Where(GenerateSiteFilterExpression<T>()).FirstAsync(func);
        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> func) where T : class => await _environmentDb.Set<T>().FirstOrDefaultAsync(func);
        public async Task<T> FirstOrDefaultAsyncFiltered<T>(Expression<Func<T, bool>> func) where T : SirketBoundBase => await _environmentDb.Set<T>().Where(GenerateSiteFilterExpression<T>()).FirstOrDefaultAsync(func);
        public async Task<T> SingleAsync<T>(Expression<Func<T, bool>> func) where T : class => await _environmentDb.Set<T>().SingleAsync(func);
        public async Task<T> SingleAsyncFiltered<T>(Expression<Func<T, bool>> func) where T : SirketBoundBase => await _environmentDb.Set<T>().Where(GenerateSiteFilterExpression<T>()).SingleAsync(func);
        public async Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> func) where T : class => await _environmentDb.Set<T>().SingleOrDefaultAsync(func);
        public async Task<T> SingleOrDefaultAsyncFiltered<T>(Expression<Func<T, bool>> func) where T : SirketBoundBase => await _environmentDb.Set<T>().Where(GenerateSiteFilterExpression<T>()).SingleOrDefaultAsync(func);
        public async Task AddAsync<T>(T data) where T : class => await _environmentDb.Set<T>().AddAsync(data);
        public void Update<T>(T data) where T : class => _environmentDb.Set<T>().Update(data);
        public async Task<SirketBoundBase> GeneralizeSirketBoundTask<TDerived>(Task<TDerived> task) where TDerived : SirketBoundBase => (SirketBoundBase)await task;
        public async Task<List<T>> GetAllParallelFiltered<T>() where T : SirketBoundBase
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<T>().Where(GenerateSiteFilterExpression<T>()).ToListAsync();
            }
        }
        public async Task<T> SingleOrDefaultParallelFiltered<T>(Expression<Func<T, bool>> func) where T : SirketBoundBase 
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Set<T>().Where(GenerateSiteFilterExpression<T>()).SingleOrDefaultAsync(func);
            }
        }

    }
}
