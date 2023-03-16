using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pristinerealty.Entity;
using Pristinerealty.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pristinerealty.Web.Areas.Admin.Pages
{
    [BindProperties]
    [Authorize]
    public class CreateModel : PageModel
    { 
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Content { get; set; }

       // public IFormFile file { get; set; }
        public string path { get; set; }

        private readonly IArticleRepository articleRepository;
        private IWebHostEnvironment hostingEnv;
        //private readonly IMapper mapper;

        public CreateModel(IArticleRepository articleRepository, IWebHostEnvironment env)
        {
            this.articleRepository = articleRepository;
            this.hostingEnv = env;
            //this.mapper = mapper;
        }

        public void OnGet()
        {
        }
        
        public void OnPost(List<IFormFile> files)
        {
            string txtValue = Request.Form["OnPost"];
            this.Content = txtValue;
            Article article = new Article
            {
                Title = this.Title,
                Content = this.Content,
                Comment = this.Comment
              
            };
         //   List<string> ImageList = new List<string>();

            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {

                        var FileDic = "Uploads";

                        string FilePath = Path.Combine(hostingEnv.WebRootPath, FileDic);

                        if (!Directory.Exists(FilePath))

                            Directory.CreateDirectory(FilePath);

                        var fileName = file.FileName;

                        var filePath = Path.Combine(FilePath, fileName);

                        string ImagePath = "~/Uploads/" + file.FileName;

                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            file.CopyTo(fs);
                            article.ImagePath = ImagePath;
                            article.Name = fileName;
                            var articleId = articleRepository.Add(article);
                        }
                     
                    }
                }
                Response.Redirect("/Admin/Index");

            }
           

          
        }
    }
}
