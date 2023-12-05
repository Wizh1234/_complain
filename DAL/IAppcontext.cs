using Complain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Complain.DAL
{
    public interface IAppDbcontext
    {
        DbSet<TenantComplainLog> TenantComplainLog { get; set; }

        Task<int> SaveChange();
    }
}