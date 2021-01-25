namespace BankPortifolio.Application.DTO
{
    public class TradeDTO : DTOBase
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }
        public string Category { get; set; }
    }
}
