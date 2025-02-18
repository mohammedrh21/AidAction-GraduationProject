using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels.Auth
{
    public class TokenRequestModel
    {
        [Required]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
        public string? FCMToken { set; get; }
    }
}
