using Microsoft.EntityFrameworkCore;

namespace DBS_grid.Data
{
    public class DBS_gridContext : DbContext
    {
        public DBS_gridContext(DbContextOptions<DBS_gridContext> options)
            : base(options)
        {
        }

        public DbSet<Models.PaymentOrder> PaymentOrder { get; set; }
    }
}
