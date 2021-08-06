using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DBS_grid.Data;
using DBS_grid.Models;

namespace DBS_grid.Pages.PaymentOrders
{
    public class CreateModel : PageModel
    {
        private readonly DBS_gridContext _context;

        public CreateModel(DBS_gridContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PaymentOrder PaymentOrder { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PaymentOrder.Add(PaymentOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
