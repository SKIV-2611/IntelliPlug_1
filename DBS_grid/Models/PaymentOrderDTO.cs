using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DBS_grid.Models
{
    public class PaymentOrderDTO
    {
        [JsonPropertyName("DboID")]
        public int ID { get; set; }
        [JsonPropertyName("PayerAccountNumber")]
        public string SenderAccount { get; set; }
        [JsonPropertyName("ReceiverAccountNumber")]
        public string ReceiverAccount { get; set; }
        [JsonPropertyName("Amount")]
        public decimal Sum { get; set; }
        [JsonPropertyName("PaymentDetails")]
        public string Reference { get; set; }

    }
}
