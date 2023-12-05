using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Complain.Models
{
    public class TenantComplainLog
    {
        [Key]
        public int ComplainID { get; set; }
        public string Complainer { get; set; }
        public string ComplainHeader { get; set; }
        public string Complain { get; set; }
        public DateTime? RegDate { get; set; }
        public int? Category { get; set; }
        public int? NatureOfComplain { get; set; }
        public int? StatusOfComplain { get; set; }

    }
}
