using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pristinerealty.Entity;
using Pristinerealty.Repository.Interface;

namespace Pristinerealty.Web.Areas.Admin.Pages
{
    [Authorize]
    public class ProjectModel : PageModel
    {
        public IEnumerable<Project> project { get; set; }
        Project Objproject { get; set; }
        private readonly IProjectRepository projectRepository;

        public string Title { get; set; }
        public string Message { get; set; }
        public string pathFile { get; set; }
        private IWebHostEnvironment hostingEnv;

        public ProjectModel(IProjectRepository projectRepository, IWebHostEnvironment env)
        {
            this.projectRepository = projectRepository;
            this.hostingEnv = env;
        }
        public async Task OnGetAsync()
        {
            project = await projectRepository.GetAllProjects();
            var sessionval = HttpContext.Session.GetString("username");
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            if (id > 0)
            {

                Objproject = await projectRepository.GetById(id);

                if (Objproject != null)
                {
                    string OldPath = Path.Combine(hostingEnv.WebRootPath, "Uploads", Objproject.ImgSrc);
                    System.IO.File.Delete(OldPath);
                    var count = projectRepository.Delete(id);
                    Message = "Entry Deleted Successfully !";
                    return RedirectToPage("/Project");

                }

            }

            return Page();

        }


    }
}
