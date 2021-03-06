using DBS_grid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DBS_grid.Pages.PaymentOrders
{
    public class DetailsModel : PageModel
    {
        private readonly DBS_grid.Data.DBS_gridContext _context;

        public DetailsModel(DBS_grid.Data.DBS_gridContext context)
        {
            _context = context;
        }

        public PaymentOrder PaymentOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PaymentOrder = await _context.PaymentOrder.FirstOrDefaultAsync(m => m.ID == id);

            if (PaymentOrder == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
