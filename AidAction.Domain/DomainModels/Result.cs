using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels
{
    public class Result<T>
    {
        public int? rv { get; set; }
        public string? Msg { get; set; }
        public T Data { get; set; }
    }
}
