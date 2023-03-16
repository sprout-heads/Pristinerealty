using System;
using System.Collections.Generic;
using System.Text;

namespace Pristinerealty.Entity
{
   public class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }


    }
}
