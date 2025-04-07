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
        Task<JArray> FAQSelectAsync();
        Task<JObject> FAQSaveAsync(FAQsModel model);
        Task<JObject> FAQDeleteAsync(object o);

        #region Campaigns
        Task<JArray> CampaignsSelectAsync();
        Task<JArray> CampaignsSelectAsync(object o);       
        Task<JObject> CampaignsArchiveAsync(object o);
        Task<JObject> CampaignStatusSaveAsync(object o);
        #endregion
    }
}
