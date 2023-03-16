
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Pristinerealty.Entity;

namespace Pristinerealty.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly IDapperService _dapperService;
       // private readonly IMapper mapper;
        public ArticleRepository(IDapperService dataService)
        {
            _dapperService = dataService;
          // this.mapper = mapper;
        }

        public async Task<IEnumerable<Article>>FileUpload(Article file)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT", DbType.String);
            var result = await Task.FromResult(_dapperService.GetAll<Article>("[dbo].[SP_SELECT_Article]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }



        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT", DbType.String);
            var result = await Task.FromResult(_dapperService.GetAll<Article>("[dbo].[SP_SELECT_Article]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
           
        }

        public async Task<Article> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT_BYID", DbType.String);
            dbparams.Add("ArticleId", id, DbType.Int32);
            var result = await Task.FromResult(_dapperService.Get<Article>("[dbo].[SP_SELECT_Article]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Add(Article Article)
        {
            
            var dbparams = new DynamicParameters();            
            dbparams.Add("Title", Article.Title, DbType.String);
            dbparams.Add("Comment", Article.Comment, DbType.String);
            dbparams.Add("Content", Article.Content, DbType.String);
            dbparams.Add("Name", Article.Name, DbType.String);
            dbparams.Add("ImagePath", Article.ImagePath, DbType.String);
            dbparams.Add("InputType", "INSERT", DbType.String);
            
            var result = await Task.FromResult(_dapperService.Add<int>("[dbo].[SP_IUD_Article]",dbparams,commandType: CommandType.StoredProcedure));
            return result;

        }

        public async Task<int> Edit(Article Article)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("ArticleId", Article.Id, DbType.Int32);
            dbparams.Add("Title", Article.Title, DbType.String);
            dbparams.Add("Comment", Article.Comment, DbType.String);
            dbparams.Add("Content", Article.Content, DbType.String);
            dbparams.Add("Name", Article.Name, DbType.String);
            dbparams.Add("ImagePath", Article.ImagePath, DbType.String);
            dbparams.Add("InputType","UPDATE", DbType.String);
            var result = await Task.FromResult(_dapperService.Edit<int>("[dbo].[SP_IUD_Article]", dbparams,commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("ArticleId",id, DbType.Int32);
            dbparams.Add("InputType","DELETE", DbType.String);
            var result = await Task.FromResult(_dapperService.Execute("[dbo].[SP_IUD_Article]",dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
                                                                                                                                                                                                                                                                                    