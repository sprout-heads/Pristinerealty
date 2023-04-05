using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pristinerealty.Entity;
using Pristinerealty.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pristinerealty.Repository;

namespace Pristinerealty.Web.Areas.Admin.Pages
{
    [Authorize]
    public class CVModel : PageModel
    {
        private readonly IResumeRepository resumeRepository;
        public IEnumerable<Resumes> cv { get; set; }
        public Resumes CV { get; set; }
        public CVModel(IResumeRepository resumeRepository)
        {
               this.resumeRepository = resumeRepository;
        }

    

        public async Task OnGetAsync()
        {
             cv= await resumeRepository.GetAllResumes();
           
        }
     
    
    }
}
