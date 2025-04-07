using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels
{
    public class CampaignModel
    {
        public int CampaignId { get; set; }
        public int? CreatorId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? TargetAmount { get; set; }
        public double? TotalFundCollected { get; set; }
        public bool? ApproveStatus { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? ImagePath { get; set; }
        public byte[] ImageBytes { get; set; }
        public int? ApprovedBy { get; set; }
        public bool? IsArchived { get; set; }
    }
}
