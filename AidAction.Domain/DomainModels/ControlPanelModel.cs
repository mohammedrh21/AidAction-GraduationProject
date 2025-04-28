using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels
{
    public class ControlPanelModel
    {
        public decimal? TotalFunds { get; set; }
        public int? TotalNeedNum { get; set; }
        public int? UrgentNeedNum { get; set; }
        public int? MonthlyNeedNum { get; set; }
        public int? CampaignNum { get; set; }
        public int? ApprovedCampaign { get; set; }
        public int? PendingCampaign { get; set; }
        public int? RejectedCampaign { get; set; }
        public List<TopFundedNeeds>? TopFundedNeeds { get; set; }
        public List<NeedModel>? RecentNeeds { get; set; }
        public List<DonationSummary>? DonationSummary { get; set; }
    }

    public class DonationSummary
    {
        public string? MonthName { get; set; }
        public decimal? TotalDonations { get; set; }
    }

    public class TopFundedNeeds
    {
        public string? Title { get; set; }
        public string? TotalFundsCollected { get; set; }
    }
}
