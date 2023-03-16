using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pristinerealty.Entity;
using Pristinerealty.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pristinerealty.Web.Areas.Admin.Pages
{
    public class ViewModel : PageModel
    {
        public UserPost userpost { get; set; }

        private readonly ILoginRepository loginRepository;
        public ViewModel(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        public async Task OnGetAsync(int id)
        {
            userpost = await loginRepository.GetUserPostByID(id);

        }
     
        [HttpPost]
        public async Task<IActionResult> OnPostEdit(int Id, IFormCollection formCollection)
        {
            if (Id > 0)
            {
                UserPost msg = await loginRepository.GetUserPostByID(Id);
                if (msg != null)
                {
                    msg.Comments = formCollection["comments"].ToString();
                    var result = await loginRepository.Update(msg);
                    return RedirectToPage("/UserpostData");
                   
                }

            }
            return Page();
        }

    }
}
