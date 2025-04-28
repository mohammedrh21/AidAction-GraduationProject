using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels
{
    public class WebsiteDetails
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? FacebookURL { get; set; }
        public string? InstagramURL { get; set; }
        public string? TikTokURL { get; set; }
        public int? CreatedBy { get; set; }
        public string? ImagePath { get; set; }
        public double? LocationLongitude { get; set; }  // Use double for precision
        public double? LocationLatitude { get; set; }   // Use double for precision
        public string? Title { get; set; }
        public string? AboutCamp { get; set; }
        public int? DonorsNum { get; set; }
        public int? CompletedCampaign { get; set; }
        public string? IBAN { get; set; }
    }

    public class ContactInfo{
        public double? LocationLongitude { get; set; }  // Use double for precision
        public double? LocationLatitude { get; set; }   // Use double for precision
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? FacebookURL { get; set; }
        public string? InstagramURL { get; set; }
        public string? TikTokURL { get; set; }
    }
}