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


        #region Donor
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

        public async Task<JArray> CampaignSaveRequestAsync(CampaignModel model)
        {
            // Use the CommandAsync method for your donor registration logic
            return await CommandAsync<JArray>("dbo.CampaignSaveRequest", model);
        }

        //CampaignSaveRequest => @Title, @Description, @TargetAmount, @CreatorId, @ImagePath
        //CampaignRequestSelect => @CreatorId 
        #endregion


    }
}
