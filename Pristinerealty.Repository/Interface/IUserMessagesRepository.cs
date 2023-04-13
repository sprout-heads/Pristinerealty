using Dapper;
using Pristinerealty.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Pristinerealty.Repository.Interface
{
    public interface IUserMessagesRepository
    {
        Task<int> Add(UserMessages msg);
        Task<IEnumerable<UserMessages>> GetAllMessages();
    }
}
