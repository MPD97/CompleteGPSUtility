using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reciver
{
    public class ReciverSettings
    {
        private readonly IConfiguration Configuration;
        public ReciverSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string ConnectionString { get { return Configuration["ReciverSettings:ConnectionString"]; } }
    }
}
