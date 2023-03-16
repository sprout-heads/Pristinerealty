using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pristinerealty.Entity;
using Pristinerealty.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pristinerealty.Web.Areas.Admin.Pages
{
    [BindProperties]
    [Authorize]
    public class IndexModel : PageModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImagePath { get; set; }
        [TempData]
        public string Message { get; set; }

        public IEnumerable<Article> article { get; set; }
        public Pristinerealty.Entity.Article Objarticle { get; set; }

        private readonly IArticleRepository articleRepository;
        private IWebHostEnvironment hostingEnv;

        public IndexModel(IArticleRepository articleRepository, IWebHostEnvironment env)
        {
            this.articleRepository = articleRepository;
            this.hostingEnv = env;
        }
        public async Task OnGetAsync()
        {
            article = await articleRepository.GetAllArticles();
            var sessionval = HttpContext.Session.GetString("username");
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            if (id > 0)
            {

                Objarticle = await articleRepository.GetById(id);

                if (Objarticle != null)
                {
                    string OldPath = Path.Combine(hostingEnv.WebRootPath, "Uploads", Objarticle.Name);
                    System.IO.File.Delete(OldPath);
                    var count = articleRepository.Delete(id);
                    Message = "Aricle Deleted Successfully !";
                    return RedirectToPage("/Index");


                }

            }

            return Page();

        }




    }
}
