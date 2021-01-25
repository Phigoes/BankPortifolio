using BankPortifolio.Domain.Entities;

namespace BankPortifolio.Domain.Factory
{
    public interface IRisk
    {
        bool CalculateRisk(Trade trade);
    }
}
