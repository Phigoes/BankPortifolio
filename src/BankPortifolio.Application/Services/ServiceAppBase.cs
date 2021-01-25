using AutoMapper;
using BankPortifolio.Application.DTO;
using BankPortifolio.Application.Interfaces;
using BankPortifolio.Domain.Entities;
using BankPortifolio.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace BankPortifolio.Application.Services
{
    public class ServiceAppBase<TEntity, TEntityDTO> : IAppBase<TEntity, TEntityDTO>
        where TEntity : EntityBase
        where TEntityDTO : DTOBase
    {
        protected readonly IServiceBase<TEntity> service;
        protected readonly IMapper iMapper;

        public ServiceAppBase(IMapper iMapper, IServiceBase<TEntity> service)
            : base()
        {
            this.iMapper = iMapper;
            this.service = service;
        }

        public void Update(TEntityDTO entity)
        {
            service.Update(iMapper.Map<TEntity>(entity));
        }

        public void Delete(int id)
        {
            service.Delete(id);
        }

        public void Delete(TEntityDTO entity)
        {
            service.Delete(iMapper.Map<TEntity>(entity));
        }

        public virtual int Insert(TEntityDTO entity)
        {
            return service.Insert(iMapper.Map<TEntity>(entity));
        }

        public TEntityDTO GetById(int id)
        {
            return iMapper.Map<TEntityDTO>(service.GetById(id));
        }

        public IEnumerable<TEntityDTO> GetAll()
        {
            return iMapper.Map<IEnumerable<TEntityDTO>>(service.GetAll());
        }
    }
}
