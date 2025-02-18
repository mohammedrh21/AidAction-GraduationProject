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
        Task<JObject> DonorSaveAsync(DonorModel model);
    }
}
