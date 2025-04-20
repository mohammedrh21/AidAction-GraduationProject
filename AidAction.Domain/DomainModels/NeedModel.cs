using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels
{
    public class NeedModel
    {
        public int NeedId { get; set; }
        public string? Title { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        public bool IsUrgent { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? TargetAmount { get; set; }
        public double? TotalFundsCollected { get; set; }
    }
}
