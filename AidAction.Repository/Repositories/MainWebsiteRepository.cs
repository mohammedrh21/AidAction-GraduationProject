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




    }
}
