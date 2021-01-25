using BankPortifolio.Domain.Entities;
using System.Collections.Generic;

namespace BankPortifolio.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        int Insert(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
