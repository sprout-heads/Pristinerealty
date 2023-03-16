using System;
using System.Collections.Generic;
using System.Text;

namespace Pristinerealty.Entity.Model
{
    public class AppSettings
    {
        public ConnectionString ConnectionStrings { get; set; }
    }
    public class ConnectionString {
        private string v;

        public ConnectionString(string v)
        {
            this.v = v;
        }

        public string DefaultConnection { get; set; }
    }
}
