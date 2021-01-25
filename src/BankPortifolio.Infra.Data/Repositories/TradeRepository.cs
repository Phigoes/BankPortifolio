using BankPortifolio.Domain.Entities;
using BankPortifolio.Domain.Interfaces.Repository;
using BankPortifolio.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace BankPortifolio.Infra.Data.Repositories
{
    public class TradeRepository : RepositoryBase<Trade>, ITradeRepository
    {
        public TradeRepository(Context context) : base(context)
        {
        }

        public int InsertUsingStoredProcedure(Trade trade)
        {
            var value = new Microsoft.Data.SqlClient.SqlParameter("@Value", trade.Value);
            var clientSector = new Microsoft.Data.SqlClient.SqlParameter("@ClientSector", trade.ClientSector);
            var tradeID = new Microsoft.Data.SqlClient.SqlParameter("@ID", SqlDbType.Int) { Direction = ParameterDirection.Output };

            context.Database.ExecuteSqlRaw("exec sp_insert_trade @Value={0}, @ClientSector={1}, @TradeID={2} out", value, clientSector, tradeID);

            if (tradeID.Value != DBNull.Value)
            {
                return (int)tradeID.Value;
            }

            return 0;
        }

        public void UpdateUsingStoredProcedure(Trade trade)
        {
            var tradeID = new Microsoft.Data.SqlClient.SqlParameter("@ID", trade.Id);
            var value = new Microsoft.Data.SqlClient.SqlParameter("@Value", trade.Value);
            var clientSector = new Microsoft.Data.SqlClient.SqlParameter("@ClientSector", trade.ClientSector);

            context.Database.ExecuteSqlRaw("exec sp_update_trade @TradeID={0}, @Value={1}, @ClientSector={2}", tradeID, value, clientSector);
        }
    }
}
