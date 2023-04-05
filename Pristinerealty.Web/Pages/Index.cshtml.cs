using Pristinerealty.Entity;
using Pristinerealty.Repository;
using Pristinerealty.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pristinerealty.Web.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly IArticleRepository articleRepository;
        private readonly ILoginRepository loginRepository;

        public IEnumerable<Article> article { get; set; }
      
        public IndexModel(ILogger<IndexModel> logger,IArticleRepository articleRepository, ILoginRepository loginRepository)
        {
            _logger = logger;
            this.loginRepository = loginRepository;
            this.articleRepository = articleRepository;
        }
         
        public  async Task<IActionResult> OnGetAsync()
        {
            article = await articleRepository.GetAllArticles();
            return Page();
        }

      

    }
}
