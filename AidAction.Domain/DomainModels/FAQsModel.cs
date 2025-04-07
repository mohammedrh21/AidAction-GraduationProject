using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels
{
    public class FAQsModel
    {
        public int FAQId { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public int CreatedBy { get; set; }
    }
}
