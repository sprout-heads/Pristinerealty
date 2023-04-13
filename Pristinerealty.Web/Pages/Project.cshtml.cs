using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pristinerealty.Entity;
using Pristinerealty.Repository.Interface;

namespace Pristinerealty.Web.Pages
{
    public class ProjectModel : PageModel
    {
        public IEnumerable<Project> project { get; set; }
        private readonly IProjectRepository projectRepository;

        public ProjectModel(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        public async Task OnGetAsync()
        {
            project = await projectRepository.GetAllProjects();
        }
    }
}
