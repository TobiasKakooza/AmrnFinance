using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amarinfinancial.Models
{
    public class FinanceContext:DbContext
    {
        public FinanceContext(DbContextOptions<FinanceContext> options) : base(options)
        {
                
        }
        public DbSet<Finance> Finances { get; set; }
    }
}
