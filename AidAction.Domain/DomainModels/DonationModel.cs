using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels
{
    public class DonationModel
    {
        public int? DonationId { get; set; }
        public int? DonorId { get; set; }
        public decimal? Amount { get; set; }
        public string? SessionId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? DonationTargetedId { get; set; }
        public int? StripeTransactionId { get; set; }
        public DateTime? DonationDate { get; set; }
        public int? PaymentStatusId { get; set; }
        public int? NeedDonationTargetedId { get; set; }
        public int? CampaignDonationTargetedId { get; set; }
    }
}
