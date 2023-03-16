using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pristinerealty.Entity;
using Pristinerealty.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pristinerealty.Web.Areas.Admin.Pages
{
    [Authorize]
    public class UserpostDataModel : PageModel
    {
        private readonly ILoginRepository loginRepository;
        public IEnumerable<UserPost> userpost { get; set; }
        public UserPost userPost { get; set; }
        public UserpostDataModel(ILoginRepository loginRepository)
        {
               this.loginRepository = loginRepository;
        }

        public async Task OnPostMarkRead(int Id)
        {
            if (Id > 0)
            {
                UserPost msg = await loginRepository.GetUserPostByID(Id);
                if (msg != null)
                {
                    msg.ReadStatus = true;
                    var result = await loginRepository.Update(msg);
                    if (result > 0)
                    {
                        userPost = await loginRepository.GetUserPostByID(Id);
                    }
                }

            }
            userpost = await loginRepository.GetAllUserPost();
        }

        public async Task OnGetAsync()
        {
            userpost = await loginRepository.GetAllUserPost();
           
        }
     
    
    }
}
