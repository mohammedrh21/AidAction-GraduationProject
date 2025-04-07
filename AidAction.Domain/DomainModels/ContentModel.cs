using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels
{
    public class ContentModel
    {
        public string FileName { get; set; }
        public byte[] FileBytes { get; set; }
    }
}
