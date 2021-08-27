
namespace DBS_grid.Models
{
    public class PaymentOrderDTO
    {
        public int DboID { get; set; }

        public string PayerAccountNumber { get; set; }

        public string ReceiverAccountNumber { get; set; }

        public decimal Amount { get; set; }

        public string PaymentDetails { get; set; }

        public PaymentOrderDTO(PaymentOrder payment)
        {
            this.DboID = payment.ID;
            this.PayerAccountNumber = payment.SenderAccount;
            this.ReceiverAccountNumber = payment.ReceiverAccount;
            this.Amount = payment.Sum;
            this.PaymentDetails = payment.Reference;
        }
    }
}
