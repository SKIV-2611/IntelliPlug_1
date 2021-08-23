using DBS_grid.Models;
using RestEase;
using System.Threading.Tasks;

namespace DBS_grid.Interfaces
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized,
        Body = BodySerializationMethod.Serialized)]
    public interface IPostPayment
    {
        [Post("api/Payments")]
        Task SendPaymentAsync([Body] PaymentOrderDTO paymentOrderDTO);
    }
}
