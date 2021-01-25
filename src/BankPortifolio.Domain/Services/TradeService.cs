using BankPortifolio.Domain.Entities;
using BankPortifolio.Domain.Interfaces.Repository;
using BankPortifolio.Domain.Interfaces.Services;

namespace BankPortifolio.Domain.Services
{
    public class TradeService : ServiceBase<Trade>, ITradeService
    {
        readonly protected ITradeRepository tradeRepository;

        public TradeService(ITradeRepository repository) : base(repository)
        {
            tradeRepository = repository;
        }

        public int InsertUsingStoredProcedure(Trade trade)
        {
            return tradeRepository.InsertUsingStoredProcedure(trade);
        }

        public void UpdateUsingStoredProcedure(Trade trade)
        {
            tradeRepository.UpdateUsingStoredProcedure(trade);
        }
    }
}
