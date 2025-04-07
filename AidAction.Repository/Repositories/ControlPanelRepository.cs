using AidAction.Domain.DomainModels;
using AidAction.Domain.Interfaces;
using AidAction.Repository.Generic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Repository.Repositories
{
    public class ControlPanelRepository : GenericRepository, IControlPanel
    {
        public ControlPanelRepository(IConfiguration configuration) : base(configuration){}



        public async Task<JObject> ContentSaveAsync(ContentModel model)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.ContentSave", model);
        }



        #region FAQs
        public async Task<JArray> FAQSelectAsync()
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JArray>("dbo.FAQSelect");
        }

        public async Task<JObject> FAQSaveAsync(FAQsModel model)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.FAQSave", model);
        }

        public async Task<JObject> FAQDeleteAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.FAQDelete", o);
        }

        #endregion

        #region Fundraiser Campaign
        public async Task<JArray> CampaignsSelectAsync()
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JArray>("dbo.CampaignSelect");
        }

        public async Task<JArray> CampaignsSelectAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JArray>("dbo.CampaignSelect",o);
        }

        public async Task<JObject> CampaignsArchiveAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.CampaignArchive", o);
        }

        public async Task<JObject> CampaignStatusSaveAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.CampaignStatusSave", o);
        }
        #endregion

    

    }

}
