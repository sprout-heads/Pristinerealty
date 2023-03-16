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
    [Authorize]
    public class EditModel : PageModel
    {
        [BindProperty]
        public string ApiTitle { get; set; }
        public int Id { get; set; }

        public string Title { get; set; }
        public string Comment { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }
        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Pristinerealty.Entity.Article article { get; set; }

        private readonly IArticleRepository articleRepository;
        private IWebHostEnvironment hostingEnv;

        public EditModel(IArticleRepository articleRepository, IWebHostEnvironment env)
        {
            this.articleRepository = articleRepository;
            this.hostingEnv = env;
        }
        public async Task OnGetAsync(int id)
        {
            article = await articleRepository.GetById(id);
            ApiTitle = this.article.Name;

        }

        public IActionResult OnPost(List<IFormFile> files)
        {

            var data = article;
            string txtValue = Request.Form["OnPost"];
            data.Content = txtValue;
            var Oldfile = this.ApiTitle;

            if (files.Count != 0)
            {
                if (Oldfile != null)
                {
                    string OldPath = Path.Combine(hostingEnv.WebRootPath, "Uploads", Oldfile);
                    System.IO.File.Delete(OldPath);
                }

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
                            var articleId = articleRepository.Edit(article);
                        }

                    }
                }

                Response.Redirect("/Admin/Index");
            }
            else
            {

                if (Oldfile != null)
                {
                    var FileDic = "Uploads";
                    string FilePath = Path.Combine(hostingEnv.WebRootPath, FileDic);
                    string ImagePath = "~/Uploads/" + Oldfile;
                    article.ImagePath = ImagePath;
                    article.Name = Oldfile;
                    var articleId = articleRepository.Edit(article);
                }
                Response.Redirect("/Admin/Index");

            }

            if (ModelState.IsValid)
            {

                var count = articleRepository.Edit(data);
                Message = "Aricle Updated Successfully !";
                return RedirectToPage("/Index");

            }
            return Page();
            //Response.Redirect("/Admin/Index");
        }


    }
}
