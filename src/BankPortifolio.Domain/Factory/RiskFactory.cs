using BankPortifolio.Infra.CrossCutting.Constant;
using System;

namespace BankPortifolio.Domain.Factory
{
    static class RiskFactory
    {
        public static IRisk Create(string risk)
        {
            switch (risk)
            {
                case TypeOfRisk.LowRisk:
                    return new LowRisk();
                case TypeOfRisk.MediumRisk:
                    return new MediumRisk();
                case TypeOfRisk.HighRisk:
                    return new HighRisk();
                default:
                    throw new Exception("Unknown risk");
            }
        }
    }
}
