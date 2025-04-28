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
        public ControlPanelRepository(IConfiguration configuration) : base(configuration) { }



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
            return await CommandAsync<JArray>("dbo.CampaignSelect", o);
        }

        public async Task<JObject> CampaignsArchiveAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.CampaignArchive", o);
        }

        public async Task<JArray> CampaignRequestSelectAsync()
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JArray>("dbo.CampaignRequestSelect");
        }
        public async Task<JArray> CampaignRequestSelectAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JArray>("dbo.CampaignRequestSelect", o);
        }

        public async Task<JObject> CampaignStatusSaveAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.CampaignStatusSave", o);
        }
        #endregion

        #region Need
        public async Task<JArray> NeedSelectAsync()
        {
            return await CommandAsync<JArray>("dbo.NeedSelect");
        }

        public async Task<JArray> NeedSelectAsync(object o)
        {
            return await CommandAsync<JArray>("dbo.NeedSelect", o);
        }

        public async Task<JObject> NeedSaveAsync(NeedModel model)
        {
            return await CommandAsync<JObject>("dbo.NeedSave", model);
        }

        public async Task<JObject> NeedDeleteAsync(object o)
        {
            return await CommandAsync<JObject>("dbo.NeedDelete", o);
        }
        #endregion

        #region Website Details
        public async Task<JArray> WebsiteDetailsSelectAsync()
        {
            return await CommandAsync<JArray>("dbo.WebsiteDetails_Contact_Select");
        }

        public async Task<JObject> WebsiteDetailsSaveAsync(WebsiteDetails model)
        {
            return await CommandAsync<JObject>("dbo.WebsiteDetails_Contact_Save", model);
        }
        #endregion

        #region Donation
        public async Task<JArray> DonationRecordsSelectAsync()
        {
            return await CommandAsync<JArray>("dbo.DonationRecordsSelect");
        }
        #endregion

        #region Index
        public async Task<JObject> ControlPanelSelectAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.ControlPanelSelect", o);
        }
        #endregion
    }

}
