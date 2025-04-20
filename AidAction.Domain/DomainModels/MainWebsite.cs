using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels
{
    public class MainWebsite
    {
        public decimal? TotalDonation { get; set; }
        public int? TotalDonors { get; set; }
        public decimal? EmergencyFundProgress { get; set; }
        public List<NeedModel>? Needs { get; set; }
        public List<CampaignModel>? Campaigns { get; set; }
    }
}
