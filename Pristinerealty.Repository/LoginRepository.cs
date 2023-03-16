
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

        public async Task<int> Add(UserPost userpost)
        {

            var dbparams = new DynamicParameters();
            dbparams.Add("Name", userpost.Name, DbType.String);
            dbparams.Add("Number", userpost.Number, DbType.String);
            dbparams.Add("Address", userpost.Address, DbType.String);
            dbparams.Add("Email", userpost.Email, DbType.String);
            dbparams.Add("Message", userpost.Message, DbType.String);
            dbparams.Add("ReadStatus", userpost.ReadStatus, DbType.String);


            dbparams.Add("InputType", "INSERT", DbType.String);

            var result = await Task.FromResult(_dapperService.Add<int>("[dbo].[SP_IUD_UserPost]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }
        public async Task<int> Update(UserPost userpost)
        {

            var dbparams = new DynamicParameters();
            dbparams.Add("UserId", userpost.UserId, DbType.String);
            dbparams.Add("Name", userpost.Name, DbType.String);
            dbparams.Add("Number", userpost.Number, DbType.String);
            dbparams.Add("Address", userpost.Address, DbType.String);
            dbparams.Add("Email", userpost.Email, DbType.String);
            dbparams.Add("Message", userpost.Message, DbType.String);
            dbparams.Add("ReadStatus", userpost.ReadStatus, DbType.String);
            dbparams.Add("Comments", userpost.Comments, DbType.String);
            dbparams.Add("InputType", "UPDATE", DbType.String);
           
            var result = await Task.FromResult(_dapperService.Edit<int>("[dbo].[SP_IUD_UserPost]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }
        public async Task<IEnumerable<UserPost>> GetAllUserPost()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT", DbType.String);
            var result = await Task.FromResult(_dapperService.GetAll<UserPost>("[dbo].[SP_SELECT_UserPost]", dbparams, commandType: CommandType.StoredProcedure));
            return result;

        }

        public async Task<UserPost> GetUserPostByID(int UserId)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("id", UserId, DbType.String);
            dbparams.Add("InputType", "SELECT_BYID", DbType.String);
            var userPost = await Task.FromResult(_dapperService.Get<UserPost>("[dbo].[SP_SELECT_UserPost]", dbparams, commandType: CommandType.StoredProcedure));
            return userPost;
        }


    }
}
