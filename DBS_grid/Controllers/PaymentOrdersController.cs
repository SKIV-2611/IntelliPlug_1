using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestEase;
using DBS_grid.Interfaces;
using DBS_grid.Models;

namespace DBS_grid.Controllers
{
    [Route("api/Payments")]
    [ApiController]
    public class PaymentOrdersController : ControllerBase
    {
        private readonly IPostPayment _postPayment;
        public PaymentOrdersController()
        {
            _postPayment =
                RestClient.For<IPostPayment>("http://localhost:54616");
        }
        [HttpPost]
        public async Task Create([Body] PaymentOrderDTO paymentOrderDTO)
        {
            await _postPayment.SendPayment(paymentOrderDTO);
        }
    }
}
