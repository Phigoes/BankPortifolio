using AutoMapper;
using BankPortifolio.Application.DTO;
using BankPortifolio.Domain.Entities;

namespace BankPortifolio.Application
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<Trade, TradeDTO>();
            CreateMap<TradeDTO, Trade>();
        }
    }
}
