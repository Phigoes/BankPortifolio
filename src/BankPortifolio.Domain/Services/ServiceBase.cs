using BankPortifolio.Domain.Entities;
using BankPortifolio.Domain.Interfaces.Repository;
using BankPortifolio.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace BankPortifolio.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        protected readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        public int Insert(TEntity entity)
        {
            return repository.Insert(entity);
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }
    }
}
