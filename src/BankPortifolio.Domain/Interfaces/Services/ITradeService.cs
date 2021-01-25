using BankPortifolio.Domain.Entities;

namespace BankPortifolio.Domain.Interfaces.Services
{
    public interface ITradeService : IServiceBase<Trade>
    {
        int InsertUsingStoredProcedure(Trade trade);
        void UpdateUsingStoredProcedure(Trade trade);
    }
}
