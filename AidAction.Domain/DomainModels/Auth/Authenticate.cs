using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels.Auth
{
    public class Authenticate
    {
        public int DonorId { get; set; }
        public string Token { get; set; }
    }
}
