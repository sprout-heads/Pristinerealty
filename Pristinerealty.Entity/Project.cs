using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pristinerealty.Entity
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Client { get; set; }


        [StringLength(100)]
        public string ImgSrc { get; set; }
        [StringLength(50)]
        public string Location { get; set; }

    }
}
