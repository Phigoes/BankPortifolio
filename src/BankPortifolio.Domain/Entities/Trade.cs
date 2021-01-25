using BankPortifolio.Domain.Factory;
using BankPortifolio.Domain.Interfaces;

namespace BankPortifolio.Domain.Entities
{
	public class Trade : EntityBase, ITrade
	{
		public double Value { get; set; }
		public string ClientSector { get; set; }
        public string Category { get; set; }

        public bool CalculateRisk(IRisk risk)
        {
            return risk.CalculateRisk(this);
        }
    }
}
