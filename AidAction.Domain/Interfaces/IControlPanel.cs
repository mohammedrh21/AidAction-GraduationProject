using AidAction.Domain.DomainModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.Interfaces
{
    public interface IControlPanel
    {
        Task<JObject> ContentSaveAsync(ContentModel model);

        #region FAQs
        Task<JArray> FAQSelectAsync();
        Task<JObject> FAQSaveAsync(FAQsModel model);
        Task<JObject> FAQDeleteAsync(object o);
        #endregion

        #region Campaigns
        Task<JArray> CampaignsSelectAsync();
        Task<JArray> CampaignsSelectAsync(object o);
        Task<JObject> CampaignsArchiveAsync(object o);

        Task<JArray> CampaignRequestSelectAsync();
        Task<JArray> CampaignRequestSelectAsync(object o);
        Task<JObject> CampaignStatusSaveAsync(object o);
        #endregion

        #region Needs
        Task<JArray> NeedSelectAsync();
        Task<JArray> NeedSelectAsync(object o);
        Task<JObject> NeedSaveAsync(NeedModel model);
        Task<JObject> NeedDeleteAsync(object o);
        #endregion

        #region Website Details
        Task<JArray> WebsiteDetailsSelectAsync();
        Task<JObject> WebsiteDetailsSaveAsync(WebsiteDetails model);
        #endregion
        #region Donation
        Task<JArray> DonationRecordsSelectAsync();
        #endregion

        #region Index
        Task<JObject> ControlPanelSelectAsync(object o);
        #endregion
    }
}
