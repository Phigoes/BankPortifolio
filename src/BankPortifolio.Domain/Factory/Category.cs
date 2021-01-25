using BankPortifolio.Domain.Entities;
using BankPortifolio.Domain.Interfaces;
using BankPortifolio.Infra.CrossCutting.Constant;
using System.Collections.Generic;
using System.Linq;

namespace BankPortifolio.Domain.Factory
{
    public class Category
    {
        private Trade portfolio;

        public Category(ITrade portfolio)
        {
            this.portfolio = (Trade)portfolio;
        }

        public string GetCategory()
        {
            List<IRisk> risks = new List<IRisk> 
            {
                RiskFactory.Create(TypeOfRisk.LowRisk),
                RiskFactory.Create(TypeOfRisk.MediumRisk),
                RiskFactory.Create(TypeOfRisk.HighRisk)
            };

            foreach (IRisk risk in risks)
            {
                if (portfolio.CalculateRisk(risk))
                    return portfolio.Category;
            }

            return TypeOfRisk.UnknownRisk.ToUpper();
        }
    }
}
