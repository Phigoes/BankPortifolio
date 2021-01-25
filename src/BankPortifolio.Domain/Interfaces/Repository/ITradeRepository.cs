using BankPortifolio.Domain.Entities;

namespace BankPortifolio.Domain.Interfaces.Repository
{
    public interface ITradeRepository : IRepositoryBase<Trade>
    {
        int InsertUsingStoredProcedure(Trade trade);
        void UpdateUsingStoredProcedure(Trade trade);
    }
}
