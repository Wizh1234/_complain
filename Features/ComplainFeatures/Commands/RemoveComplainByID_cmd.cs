using Complain.DAL;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Complain.Features.ComplainFeatures.Commands
{
    public class RemoveComplainByID_cmd : IRequest<int>
    {
        public int ComplainID { get; set; }

        

        public class RemoveComplainByID_cmdHandler : IRequestHandler(RemoveComplainByID_cmd, int)
        {
            private readonly IAppDbcontext _context;
            public RemoveComplainByID_cmdHandler(IAppDbcontext context)
            {
                _context = context;
            }

            public async Task<int> Handle(RemoveComplainByID_cmd command, CancellationToken cancellationToken)
            {
                var tc = _context.TenantComplainLog.Where(a => a.ComplainID == command.ComplainID).FirstOrDefault();
                if (tc != null)
                {
                    _context.TenantComplainLog.Remove(tc);
                    await _context.SaveChange();
                    return command.ComplainID;
                }
                else
                {
                    return default;
                }
            }
        }


      
    }
}
