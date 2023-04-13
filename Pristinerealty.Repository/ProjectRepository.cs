using Dapper;
using Pristinerealty.Entity;
using Pristinerealty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Pristinerealty.Repository
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly IDapperService _dapperService;
        public ProjectRepository(IDapperService dataService)
        {
            _dapperService = dataService;
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT", DbType.String);
            var result = await Task.FromResult(_dapperService.GetAll<Project>("[dbo].[SP_SELECT_Projects]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }

        public async Task<Project> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT_BYID", DbType.String);
            dbparams.Add("id", id, DbType.Int32);
            var result = await Task.FromResult(_dapperService.Get<Project>("[dbo].[SP_SELECT_Projects]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }




        public async Task<int> Add(Project project)
        {

            var dbparams = new DynamicParameters();
            dbparams.Add("title", project.Title, DbType.String);
            dbparams.Add("client", project.Client, DbType.String);
            dbparams.Add("imgsrc", project.ImgSrc, DbType.String);
            dbparams.Add("location", project.Location, DbType.String);
            dbparams.Add("InputType", "INSERT", DbType.String);

            var result = await Task.FromResult(_dapperService.Add<int>("[dbo].[SP_IUD_Projects]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }


        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", id, DbType.Int32);
            dbparams.Add("InputType", "DELETE", DbType.String);
            var result = await Task.FromResult(_dapperService.Execute("[dbo].[SP_IUD_Projects]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }

}
