using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestEase;
using DBS_grid.Models;

namespace DBS_grid.Interfaces
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized,
        Body = BodySerializationMethod.Serialized)]
    public interface IPostPayment
    {
        [Post("api/Payments")]
        Task SendPayment([Body] PaymentOrderDTO paymentOrderDTO);
    }
}
