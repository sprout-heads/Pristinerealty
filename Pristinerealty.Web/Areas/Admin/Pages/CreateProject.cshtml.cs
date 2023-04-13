using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pristinerealty.Entity;
using Pristinerealty.Repository.Interface;

namespace Pristinerealty.Web.Areas.Admin.Pages
{
    public class CreateProjectModel : PageModel
    {

        private readonly IProjectRepository projectRepository;
        private IWebHostEnvironment hostingEnv;

        public CreateProjectModel(IProjectRepository projectRepository, IWebHostEnvironment env)
        {
            this.projectRepository = projectRepository;
            this.hostingEnv = env;
        }
        public void OnGet()
        {
        }

        public void OnPost(List<IFormFile> files)
        {
            string txtTitle = Request.Form["Title"];
            string client = Request.Form["Client"];
            string category = Request.Form["Category"];
            string status = Request.Form["Status"];
            string location = Request.Form["Location"];
            Project project = new Project();

            if (files != null)
            {
                foreach (var item in files)
                {
                    if (item.Length > 0)
                    {

                        var FileDic = "Project";

                        string FilePath = Path.Combine(hostingEnv.WebRootPath, FileDic);

                        if (!Directory.Exists(FilePath))

                            Directory.CreateDirectory(FilePath);

                        var fileName = item.FileName;

                        var filePath = Path.Combine(FilePath, fileName);

                        string ImagePath = "~/Project/" + item.FileName;

                        using (FileStream fs = System.IO.File.Create(filePath))
                        {
                            item.CopyTo(fs);
                            project.Title = txtTitle;
                            project.Client = client;
                            project.ImgSrc = ImagePath;
                            project.Location = location;

                            var projectId = projectRepository.Add(project);
                        }


                    }
                }
                Response.Redirect("/Admin/Project");
            }
        }
    }
}
