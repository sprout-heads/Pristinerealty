
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Pristinerealty.Entity;
using Pristinerealty.Repository;
using Pristinerealty.Repository.Interface;

namespace Pristinerealty.Repository
{
   public class LoginRepository : ILoginRepository
    {
        private readonly IDapperService _dapperService;
        public LoginRepository(IDapperService dataService)
        {
            _dapperService = dataService;
        }

        public async Task<int> FindLogin(Login login)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("UserName", login.UserName, DbType.String);
            dbparams.Add("Password", login.Password, DbType.String);
            dbparams.Add("InputType", "CHECKLOGIN", DbType.String);
            var result = await Task.FromResult(_dapperService.Execute("[dbo].[SP_SELECT_Login]", dbparams, commandType: CommandType.StoredProcedure));

            return result;
        }

        public async Task<IEnumerable<Login>> getSessionRank(Login login)
        {

            var dbparams = new DynamicParameters();
            dbparams.Add("UserName", login.UserName, DbType.String);
            dbparams.Add("Password", login.Password, DbType.String);
            dbparams.Add("InputType", "SESSIONID", DbType.String);
            var result = await Task.FromResult(_dapperService.GetAll<Login>("[dbo].[SP_SELECT_Login]", dbparams, commandType: CommandType.StoredProcedure));
            return result;


        }

      
    }
}
