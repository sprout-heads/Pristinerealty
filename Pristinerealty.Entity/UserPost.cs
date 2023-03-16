using System;
using System.Collections.Generic;
using System.Text;

namespace Pristinerealty.Entity
{
   public class UserPost
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        //public string Department { get; set; }
        //public string Doctor { get; set; }
        public string Message { get; set; }
        public bool ReadStatus { get; set; }
        public string Comments { get; set; }
    }
}
