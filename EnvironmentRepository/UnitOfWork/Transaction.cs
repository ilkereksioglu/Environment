using EnvironmentRepository.Database;
using EnvironmentRepository.Models.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentRepository.UnitOfWork
{
    public interface ITransaction
    {
        public void SaveChanges();
        public Task SaveChangesAsync();
    }

    public class Transaction : ITransaction
    {
        private readonly EnvironmentDbContext _environmentDb;
        public Transaction(EnvironmentDbContext environmentDb)
        {
            _environmentDb = environmentDb;
        }

        public void SaveChanges()
        {
            _environmentDb.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            var entries = _environmentDb.ChangeTracker.Entries<VeriListesi>().Where(
                e => e.State == Microsoft.EntityFrameworkCore.EntityState.Modified 
                || e.State == Microsoft.EntityFrameworkCore.EntityState.Added 
                || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
            await _environmentDb.SaveChangesAsync();
        }
    }
}
