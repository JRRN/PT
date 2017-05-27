namespace Domain.Model
{
    public class Polices
    {
        public int Id { get; set; }
        public decimal amountInsured { get; set; }
        public string email { get; set; }
        public System.DateTime inceptionDate { get; set; }
        public bool installmentPayment { get; set; }
        public string clientId { get; set; }
        public string ObjetId { get; set; }
    }
}