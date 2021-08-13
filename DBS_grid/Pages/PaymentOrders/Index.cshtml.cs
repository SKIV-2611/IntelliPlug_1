using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestEase;
using Newtonsoft.Json;
using DBS_grid.Data;
using DBS_grid.Models;
using DBS_grid.Interfaces;

namespace DBS_grid.Pages.PaymentOrders
{
    public class IndexModel : PageModel
    {
        private readonly DBS_gridContext _context;
        private readonly IPostPayment _postPayment;

        public IndexModel(DBS_gridContext context)
        {
            _context = context;
            _postPayment =
                RestClient.For<IPostPayment>("https://localhost:44382");
        }

        public IList<PaymentOrder> PaymentOrder { get;set; }

        public async Task OnGetAsync()
        {
            PaymentOrder = await _context.PaymentOrder.ToListAsync();
        }


        public async Task<IActionResult> OnPostSendAllAsync()
        {
            var paymentOrders =
                _context.PaymentOrder.Where
                (p => p.Status == Models.PaymentOrder.OrderStatus.NotSent);
            
            foreach(PaymentOrder po in paymentOrders)
            {
                po.Status = Models.PaymentOrder.OrderStatus.Processing;
                await _postPayment.SendPaymentAsync(new PaymentOrderDTO(po));
            }
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendOneAsync(int id)
        {
            var paymentOrder = _context.PaymentOrder.Find(id);
            if(paymentOrder != null)
            {
                paymentOrder.Status = Models.PaymentOrder.OrderStatus.Processing;
                await _postPayment.SendPaymentAsync(new PaymentOrderDTO(paymentOrder));
            }
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

    }
}
