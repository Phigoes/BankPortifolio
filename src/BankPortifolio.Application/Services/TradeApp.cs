using AutoMapper;
using BankPortifolio.Application.DTO;
using BankPortifolio.Application.Interfaces;
using BankPortifolio.Domain.Entities;
using BankPortifolio.Domain.Factory;
using BankPortifolio.Domain.Interfaces;
using BankPortifolio.Domain.Interfaces.Services;

namespace BankPortifolio.Application.Services
{
    public class TradeApp : ServiceAppBase<Trade, TradeDTO>, ITradeApp
    {
        readonly protected ITradeService tradeService;

        public TradeApp(IMapper iMapper, ITradeService service) : base(iMapper, service)
        {
            tradeService = service;
        }

        public int Insert(TradeDTO tradeDTO, bool useStoredProcedure)
        {
            if (useStoredProcedure)
                return tradeService.InsertUsingStoredProcedure(iMapper.Map<Trade>(tradeDTO));

            tradeDTO.Category = GetCategory(tradeDTO);

            return service.Insert(iMapper.Map<Trade>(tradeDTO));
        }

        public void Update(TradeDTO tradeDTO, bool useStoredProcedure)
        {
            if (useStoredProcedure)
            {
                tradeService.UpdateUsingStoredProcedure(iMapper.Map<Trade>(tradeDTO));
                return;
            }

            tradeDTO.Category = GetCategory(tradeDTO);

            service.Update(iMapper.Map<Trade>(tradeDTO));
        }

        public string GetCategory(TradeDTO tradeDTO)
        {
            ITrade trade = iMapper.Map<Trade>(tradeDTO);

            return new Category(trade).GetCategory();
        }
    }
}
