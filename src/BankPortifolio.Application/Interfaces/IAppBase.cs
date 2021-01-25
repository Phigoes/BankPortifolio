using BankPortifolio.Application.DTO;
using BankPortifolio.Domain.Entities;
using System.Collections.Generic;

namespace BankPortifolio.Application.Interfaces
{
    public interface IAppBase<TEntity, TEntityDTO>
        where TEntity : EntityBase
        where TEntityDTO : DTOBase
    {
        int Insert(TEntityDTO entity);
        void Delete(int id);
        void Delete(TEntityDTO entity);
        void Update(TEntityDTO entity);
        TEntityDTO GetById(int id);
        IEnumerable<TEntityDTO> GetAll();
    }
}
