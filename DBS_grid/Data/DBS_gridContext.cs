using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DBS_grid.Models;

namespace DBS_grid.Data
{
    public class DBS_gridContext : DbContext
    {
        public DBS_gridContext (DbContextOptions<DBS_gridContext> options)
            : base(options)
        {
        }

        public DbSet<DBS_grid.Models.PaymentOrder> PaymentOrder { get; set; }
    }
}
