using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBS_grid.Data;
using DBS_grid.Models;

namespace DBS_grid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentOrdersController : ControllerBase
    {
        private readonly DBS_gridContext _context;

        public PaymentOrdersController(DBS_gridContext context)
        {
            _context = context;
        }

        // GET: api/PaymentOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentOrder>>> GetPaymentOrder()
        {
            return await _context.PaymentOrder.ToListAsync();
        }

        // GET: api/PaymentOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentOrder>> GetPaymentOrder(int id)
        {
            var paymentOrder = await _context.PaymentOrder.FindAsync(id);

            if (paymentOrder == null)
            {
                return NotFound();
            }

            return paymentOrder;
        }

        // PUT: api/PaymentOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentOrder(int id, PaymentOrder paymentOrder)
        {
            if (id != paymentOrder.ID)
            {
                return BadRequest();
            }

            _context.Entry(paymentOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentOrder>> PostPaymentOrder(PaymentOrder paymentOrder)
        {
            _context.PaymentOrder.Add(paymentOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentOrder", new { id = paymentOrder.ID }, paymentOrder);
        }

        // DELETE: api/PaymentOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentOrder(int id)
        {
            var paymentOrder = await _context.PaymentOrder.FindAsync(id);
            if (paymentOrder == null)
            {
                return NotFound();
            }

            _context.PaymentOrder.Remove(paymentOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentOrderExists(int id)
        {
            return _context.PaymentOrder.Any(e => e.ID == id);
        }
    }
}
