using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBS_grid.Models
{
    public class PaymentOrder
    {
        public int ID { get; set; }

        [Display(Name = "Счёт отправителя")]
        [Required]
        public string SenderAccount { get; set; }
        [Display(Name = "Счёт получателя")]
        [Required]
        public string ReceiverAccount { get; set; }
        [Display(Name = "Сумма")]
        public decimal Sum { get; set; }
        [Display(Name = "Назначение платежа")]
        [Required]
        public string Reference { get; set; }
        
        public enum OrderStatus
        {
            [Display(Name = "Обработка")]
            Processing = 1,
            [Display(Name = "Исполнен")]
            Performed = 2,
            [Display(Name = "Отказан")]
            Refused = 3,
            [Display(Name = "Не отправлен")]
            NotSent = 4
        };
        [Display(Name = "Статус")]
        public OrderStatus Status { get; set; } = OrderStatus.NotSent;
    }
}
