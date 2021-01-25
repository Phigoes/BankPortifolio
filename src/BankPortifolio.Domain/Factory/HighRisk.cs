using BankPortifolio.Domain.Entities;
using BankPortifolio.Infra.CrossCutting.Constant;

namespace BankPortifolio.Domain.Factory
{
    class HighRisk : IRisk
    {
        public bool CalculateRisk(Trade trade)
        {
            if (trade.Value > 1000000 && trade.ClientSector == TypeOfSector.Private)
            {
                trade.Category = TypeOfRisk.HighRisk.ToUpper();

                return true;
            }

            return false;
        }
    }
}
