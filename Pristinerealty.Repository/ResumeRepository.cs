using Dapper;
using Pristinerealty.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Pristinerealty.Repository
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly IDapperService _dapperService;
        // private readonly IMapper mapper;
        public ResumeRepository(IDapperService dataService)
        {
            _dapperService = dataService;
            // this.mapper = mapper;
        }

        public async Task<IEnumerable<Resumes>> FileUpload(Resumes file)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT", DbType.String);
            var result = await Task.FromResult(_dapperService.GetAll<Resumes>("[dbo].[SP_SELECT_Resumes]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }


        public async Task<IEnumerable<Resumes>> GetAllResumes()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT", DbType.String);
            var result = await Task.FromResult(_dapperService.GetAll<Resumes>("[dbo].[SP_SELECT_Resumes]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<Resumes> GetById(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT_BYID", DbType.String);
            dbparams.Add("Id", id, DbType.Int32);
            var result = await Task.FromResult(_dapperService.Get<Resumes>("[dbo].[SP_SELECT_Resumes]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Add(Resumes cv)
        {

            var dbparams = new DynamicParameters();
            dbparams.Add("Name", cv.Name, DbType.String);
            dbparams.Add("Mobile", cv.Mobile, DbType.String);
            dbparams.Add("Email", cv.Email, DbType.String);
            dbparams.Add("Location", cv.Location, DbType.String);
            dbparams.Add("Message", cv.Message, DbType.String);
            dbparams.Add("FilePath", cv.FileURL, DbType.String);
            dbparams.Add("InputType", "INSERT", DbType.String);

            var result = await Task.FromResult(_dapperService.Add<int>("[dbo].[SP_IUD_Resume]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }

        public async Task<int> Edit(Resumes cv)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", cv.ID, DbType.Int32);
            dbparams.Add("Name", cv.Name, DbType.String);
            dbparams.Add("Mobile", cv.Mobile, DbType.String);
            dbparams.Add("Email", cv.Email, DbType.String);
            dbparams.Add("Location", cv.Location, DbType.String);
            dbparams.Add("Message", cv.Message, DbType.String);
            dbparams.Add("FilePath", cv.FileURL, DbType.String);
            dbparams.Add("InputType", "INSERT", DbType.String);
            var result = await Task.FromResult(_dapperService.Edit<int>("[dbo].[SP_IUD_Resume]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<int> Delete(int id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("Id", id, DbType.Int32);
            dbparams.Add("InputType", "DELETE", DbType.String);
            var result = await Task.FromResult(_dapperService.Execute("[dbo].[SP_IUD_Resume]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }
    }
}
