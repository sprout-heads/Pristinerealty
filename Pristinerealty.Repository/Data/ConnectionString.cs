using Pristinerealty.Entity.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pristinerealty.Repository
{
    public  class ConnectionString
    {
        private static string Connectionstring = "DefaultConnection";


        private   readonly IOptions<AppSettings> _options;

        public ConnectionString(IOptions<AppSettings> options)
        {
            _options = options;
        }

        public   string Value {
            get
            {
                return ConfigurationManager.ConnectionStrings[_options.Value.ConnectionStrings.DefaultConnection].ConnectionString;
            }
        }
    }
}
