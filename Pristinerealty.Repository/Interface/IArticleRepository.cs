using Pristinerealty.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pristinerealty.Repository
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllArticles();
        Task<Article> GetById(int id);
        Task<int> Add(Article Article);
        Task<int> Edit(Article Article);
        Task<int> Delete(int id);
        

    }
}
