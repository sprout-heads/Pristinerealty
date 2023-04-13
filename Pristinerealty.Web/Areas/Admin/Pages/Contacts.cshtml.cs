using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pristinerealty.Entity;
using Pristinerealty.Repository.Interface;

namespace Pristinerealty.Web.Areas.Admin.Pages
{
    [BindProperties]
    [Authorize]
    public class ContactsModel : PageModel
    {
        private readonly IUserMessagesRepository userMsgRepository;
        public IEnumerable<UserMessages> msgs { get; set; }
        public ContactsModel(IUserMessagesRepository userMsgRepository)
        {
            this.userMsgRepository = userMsgRepository;
        }

        public async Task OnGetAsync()
        {
            msgs = await userMsgRepository.GetAllMessages();
            
        }
    }
}
