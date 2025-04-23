using AidAction.Domain.DomainModels;
using AidAction.Domain.DTO;
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
    public class MainWebsiteRepository : GenericRepository, IMainWebsite
    {
        public MainWebsiteRepository(IConfiguration configuration) : base(configuration) { }

        #region Main
        public async Task<JObject> MainWebsiteSelectAsync()
        {
            return await CommandAsync<JObject>("dbo.MainWebsiteSelect");
        }
        #endregion

        #region Donor
        public async Task<JObject> DonorSelectAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.DonorSelect", o);
        }
        public async Task<JObject> UpdateDonorSaveAsync(DonorModel model)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.DonorSave", model);
        }

        public async Task<JObject> DonorSaveAsync(DonorModel model)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.DonorRegister", model);
        }
        #endregion

        #region FAQs
        public async Task<JArray> FAQSelectAsync()
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JArray>("dbo.FAQSelect");
        }

        #endregion

        #region Fundraiser Campaign
        public async Task<JArray> CampaignsSelectAsync()
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JArray>("dbo.CampaignSelect");
        }

        public async Task<JArray> CampaignSelectAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JArray>("dbo.CampaignsSelect", o);
        }

        public async Task<JArray> CampaignsSelectAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JArray>("dbo.CampaignSelect", o);
        }

        public async Task<JObject> CampaignRequestSelectAsync(object o)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JObject>("dbo.CampaignRequestSelect", o);
        }

        public async Task<JArray> CampaignSaveRequestAsync(AddCampaignModel model)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JArray>("dbo.CampaignSaveRequest", model);
        }

        //CampaignSaveRequest => @Title, @Description, @TargetAmount, @CreatorId, @ImagePath
        //CampaignRequestSelect => @CreatorId 
        #endregion

        #region WebsiteDetails
        public async Task<JArray> WebsiteDetailsSelectAsync()
        {
            return await CommandAsync<JArray>("dbo.WebsiteDetails_Contact_Select");
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
        #endregion

        #region Donation
        public async Task<JArray> DonationRecordsSelectAsync(object o)
        {
            return await CommandAsync<JArray>("dbo.DonationRecordsSelect", o);
        }

        public async Task<JObject> DonationSaveAsync(DonationModel model)
        {
            return await CommandAsync<JObject>("dbo.DonationSave", model);
        }
        #endregion
    }
}
