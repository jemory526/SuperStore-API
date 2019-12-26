using System.Collections.Generic;
using SuperStore_API.Web.Models;

namespace SuperStore_API.Web.Services
{
    public interface IUsersService
    {
        int Create(UsersCreateRequest request);
        void Delete(int id);
        List<User> GetAll();
        User GetById(int id);
        void Update(UsersUpdateRequest req);
    }
}