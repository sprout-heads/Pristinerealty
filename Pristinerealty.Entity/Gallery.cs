﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pristinerealty.Entity
{
   public class Gallery
    {

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Path { get; set; }
        public int? NoOfViews { get; set; }
        [NotMappedAttribute]
        [Required(ErrorMessage = "Photo is required.")]
        public List<IFormFile> file { get; set; }


    }
}
