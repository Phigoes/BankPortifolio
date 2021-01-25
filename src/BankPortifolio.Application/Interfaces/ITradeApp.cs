using BankPortifolio.Application.DTO;
using BankPortifolio.Domain.Entities;

namespace BankPortifolio.Application.Interfaces
{
    public interface ITradeApp: IAppBase<Trade, TradeDTO>
    {
        int Insert(TradeDTO entity, bool useStoredProcedure);
        void Update(TradeDTO entity, bool useStoredProcedure);
    }
}
