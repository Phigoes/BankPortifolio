using BankPortifolio.Domain.Entities;
using BankPortifolio.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;

namespace BankPortifolio.Infra.Data.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Trade> Trades { get; set; }

        public IDbContextTransaction Transaction { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            if (Database.GetPendingMigrations().Count() > 0)
                Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public IDbContextTransaction InitTransaction()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }

        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Save()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Save();
            Commit();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TradeMap());
        }
    }
}
