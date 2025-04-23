using AidAction.Domain.DomainModels;
using AidAction.Domain.DomainModels.Auth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.Interfaces
{
    public interface IMainWebsite
    {
        #region MainWebsite
        Task<JObject> MainWebsiteSelectAsync();
        #endregion

        #region Donor
        Task<JObject> DonorSelectAsync(object o);
        Task<JObject> UpdateDonorSaveAsync(DonorModel model);
        Task<JObject> DonorSaveAsync(DonorModel model);
        #endregion

        #region FAQs
        Task<JArray> FAQSelectAsync();
        #endregion

        #region Fundraiser Campaign
        Task<JArray> CampaignsSelectAsync();
        Task<JArray> CampaignsSelectAsync(object o);
        Task<JObject> CampaignRequestSelectAsync(object o);
        Task<JArray> CampaignSaveRequestAsync(AddCampaignModel model);
        #endregion

        #region WebsiteDetails
        Task<JArray> WebsiteDetailsSelectAsync();
        #endregion

        #region Need
        Task<JArray> NeedSelectAsync();
        Task<JArray> NeedSelectAsync(object o);
        #endregion

        #region Donation       
        Task<JArray> DonationRecordsSelectAsync(object o);
        Task<JObject> DonationSaveAsync(DonationModel model);
        #endregion
    }
}
