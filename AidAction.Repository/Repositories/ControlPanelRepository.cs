using AidAction.Domain.Interfaces;
using AidAction.Repository.Generic;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Repository.Repositories
{
    public class ControlPanelRepository : GenericRepository, IControlPanel
    {
        public ControlPanelRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }









}
