using Complain.DAL;
using Complain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Complain.Features.ComplainFeatures.Queries
{
    public class GetAllComplains:IRequest<IEnumerable<TenantComplainLog>>
    {
        private readonly AppDbcontext _context;

        public GetAllComplains(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TenantComplainLog>> Handler(GetAllComplains query,CancellationToken cancellation)
        {
            var tl = await _context.TenantComplainLog.ToListAsync();
            if (tl == null)
            {
                return null;
            }

            return tl.AsReadOnly();
        }
    }
}
