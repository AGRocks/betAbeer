using BetABeer.Model.ModelEntities;
using BetABeer.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BetABeer.Model
{
    public class ModelContext : DbContext, IDbDataProvider, IUnitOfWork
    {
        public ModelContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reward> Rewards { get; set; }

        public IQueryable<T> GetDbSetAsQueryable<T>() where T : class
        {
            return this.Set<T>().AsQueryable();
        }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return this.Set<T>();
        }

        public void Save()
        {
            base.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}