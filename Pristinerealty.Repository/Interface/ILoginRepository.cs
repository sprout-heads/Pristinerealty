using Pristinerealty.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pristinerealty.Repository.Interface
{
    public interface ILoginRepository
    {
        Task<int> FindLogin(Login login);
        Task<IEnumerable<Login>> getSessionRank(Login login);
        Task<int> Add(UserPost userpost);
        Task<IEnumerable<UserPost>> GetAllUserPost();
        Task<UserPost> GetUserPostByID(int UserId);
        Task<int> Update(UserPost userpost);
    }
}
