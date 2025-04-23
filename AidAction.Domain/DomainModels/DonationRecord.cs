using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AidAction.Domain.DomainModels
{
    public class DonationRecord
    {
        public int? DonorId { get; set; }
        public int? DonationId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DonationDate { get; set; }
        public string? SessionId { get; set; }
        public bool IsNeed { get; set; }
        public int? EntityId { get; set; }
        public string? DonationNTitle { get; set; }
        public string? DonationCTitle { get; set; }


        public int? DonationTargetedId { get; set; }
        public string? DonationTargetedTitle { get; set; }
        public string? StripeTransactionId { get; set; }
    }

    public class DonationFilterModel
    {
        public string DonorName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string DonationTargeted { get; set; } = "All";
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
    }
}
