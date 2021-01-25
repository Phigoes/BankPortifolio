using BankPortifolio.Domain.Entities;
using BankPortifolio.Infra.CrossCutting.Constant;

namespace BankPortifolio.Domain.Factory
{
    class LowRisk : IRisk
    {
        public bool CalculateRisk(Trade trade)
        {
            if (trade.Value < 1000000 && trade.ClientSector == TypeOfSector.Public)
            {
                trade.Category = TypeOfRisk.LowRisk.ToUpper();

                return true;
            }

            return false;
        }
    }
}
