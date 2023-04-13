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
    public class UserMessagesRepository : IUserMessagesRepository
    {
        private readonly IDapperService _dapperService;

        public UserMessagesRepository(IDapperService dataService)
        {
            _dapperService = dataService;
           
        }
        public async Task<int> Add(UserMessages msg)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("FName", msg.FirstName, DbType.String);
            dbparams.Add("LName", msg.LastName, DbType.String);
            dbparams.Add("Email", msg.Email, DbType.String);
            dbparams.Add("Number", msg.Number, DbType.String);
            dbparams.Add("Message", msg.Message, DbType.String);
            dbparams.Add("InputType", "INSERT", DbType.String);
            var result = await Task.FromResult(_dapperService.Add<int>("[dbo].[SP_IUD_UserMsg]", dbparams, commandType: CommandType.StoredProcedure));
            return result;
        }

        public async Task<IEnumerable<UserMessages>> GetAllMessages()
        {
            var dbparams = new DynamicParameters();
            dbparams.Add("InputType", "SELECT", DbType.String);
            var result = await Task.FromResult(_dapperService.GetAll<UserMessages>("[dbo].[SP_SELECT_UserMsg]", dbparams, commandType: CommandType.StoredProcedure));
         
            return result;
        }
    }
}
