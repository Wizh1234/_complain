using Complain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Complain.DAL
{
    public class AppDbcontext : DbContext, IAppDbcontext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options) { }

        public DbSet<TenantComplainLog> TenantComplainLog { get; set; }

        public async Task<int> SaveChange()
        {
            return await base.SaveChangesAsync();
        }
    }
}
