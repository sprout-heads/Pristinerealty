using System;
using System.Collections.Generic;
using System.Text;

namespace Pristinerealty.Entity
{
   public class Resumes
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string FileURL { get; set; }
        public string Location { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
