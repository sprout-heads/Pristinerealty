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
    [BindProperties]
    public class ContactModel : PageModel
    {
        private readonly IUserMessagesRepository userMsgRepository;
        public IEnumerable<UserMessages> msgs { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
 
        public string Email { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }
        public ContactModel(IUserMessagesRepository userMsgRepository)
        {
            this.userMsgRepository = userMsgRepository;
        }
        public void OnGet()
        {
        }

        //public async Task OnGetAsync()
        //{
        //    msgs = await userMsgRepository.GetAllMessages();

        //}

        public void OnPost()
        {
          
            UserMessages usr = new UserMessages
            {
                FirstName=this.FirstName,
                LastName=this.LastName,
                Number=this.Number,
                Email=this.Email,
                Message=this.Message

            };
            var Id = userMsgRepository.Add(usr);
            //   List<string> ImageList = new List<string>();


           
                Response.Redirect("/Index");

            }



        }
    }

