using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBS_grid.Data;
using DBS_grid.Models;

namespace DBS_grid.Pages.PaymentOrders
{
    public class IndexModel : PageModel
    {
        private readonly DBS_grid.Data.DBS_gridContext _context;

        public IndexModel(DBS_grid.Data.DBS_gridContext context)
        {
            _context = context;
        }

        public IList<PaymentOrder> PaymentOrder { get;set; }

        public async Task OnGetAsync()
        {
            PaymentOrder = await _context.PaymentOrder.ToListAsync();
        }
    }
}
