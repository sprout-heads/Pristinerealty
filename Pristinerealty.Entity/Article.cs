using Microsoft.AspNetCore.Http;
using System;

namespace Pristinerealty.Entity
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Comment { get; set; } 
        public string Content { get; set; }
        public IFormFile file { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string ImagePath { get; set; }

     
    }
}
