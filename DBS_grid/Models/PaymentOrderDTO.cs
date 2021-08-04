using System;
//using System.Text.Json.Serialization;

namespace DBS_grid.Models
{
    public class PaymentOrderDTO
    {
        //[JsonPropertyName("DboID")]
        //public int ID { get; set; }
        public int DboID { get; set; }
        //[JsonPropertyName("PayerAccountNumber")]
        //public string SenderAccount { get; set; }
        public string PayerAccountNumber { get; set; }
        //[JsonPropertyName("ReceiverAccountNumber")]
        //public string ReceiverAccount { get; set; }
        public string ReceiverAccountNumber { get; set; }
        //[JsonPropertyName("Amount")]
        //public decimal Sum { get; set; }
        public decimal Amount { get; set; }
        //[JsonPropertyName("PaymentDetails")]
        //public string Reference { get; set; }
        public string PaymentDetails { get; set; }

        public PaymentOrderDTO (PaymentOrder payment)
        {
            this.DboID = payment.ID;
            this.PayerAccountNumber = payment.SenderAccount;
            this.ReceiverAccountNumber = payment.ReceiverAccount;
            this.Amount = payment.Sum;
            this.PaymentDetails = payment.Reference;
        }
    }
}
