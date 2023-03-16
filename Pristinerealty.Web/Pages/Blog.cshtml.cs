using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pristinerealty.Entity;
using Pristinerealty.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Pristinerealty.Web.Pages
{
    public class BlogModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IArticleRepository articleRepository;

        public IEnumerable<Article> article { get; set; }

        public BlogModel(ILogger<IndexModel> logger, IArticleRepository articleRepository)
        {
            _logger = logger;
            this.articleRepository = articleRepository;
        }

        public async Task OnGetAsync()
        {
            article = await articleRepository.GetAllArticles();

        }
    }
}
