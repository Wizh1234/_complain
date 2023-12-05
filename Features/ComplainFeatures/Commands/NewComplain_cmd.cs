using Complain.DAL;
using Complain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Complain.Features.ComplainFeatures.Commands
{
    public class NewComplain_cmd : IRequest<int>
    {

        public string Complainer { get; set; }
        public string ComplainHeader { get; set; }
        public string Complain { get; set; }
        public DateTime? RegDate { get; set; }
        public int? Category { get; set; }
        public int? NatureOfComplain { get; set; }
        public int? StatusOfComplain { get; set; }


        public class NewComplain_cmdHander : IRequestHandler<NewComplain_cmd, int>
        {
            private readonly IAppDbcontext _context;
            public NewComplain_cmdHander(IAppDbcontext context)
            {
                _context = context;
            }

            public async Task<int> Handle(NewComplain_cmd command, CancellationToken cancellationToken)
            {
                var tc = new TenantComplainLog();
                tc.Complainer = command.Complainer;
                tc.ComplainHeader = command.ComplainHeader;
                tc.Complain = command.Complain;
                tc.Category = command.Category;
                tc.NatureOfComplain = command.NatureOfComplain;
                tc.StatusOfComplain = 1;
                tc.RegDate = DateTime.Now;
                _context.TenantComplainLog.Add(tc);
                await _context.SaveChange();
                return tc.ComplainID;
            }

            int IRequestHandler<NewComplain_cmd, int>.Handle(NewComplain_cmd message)
            {
                throw new NotImplementedException();
            }
        }
    }
}
