using BankPortifolio.Infra.CrossCutting.Constant;
using System.Collections.Generic;

namespace BankPortifolio.Infra.CrossCutting
{
    public class TypeOfClientSector
    {
		public string Name { get; set; }
		public string Value { get; set; }

		public static IEnumerable<TypeOfClientSector> GetAllTypeOfClientSector()
		{
			yield return new TypeOfClientSector { Name = "Private", Value = TypeOfSector.Private };
			yield return new TypeOfClientSector { Name = "Public", Value = TypeOfSector.Public };
		}
	}
}
