using CRUD_application_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_application_2.Interfaces
{
    public interface IUserService
    {
        User GetUser(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        IList<User> GetUsers();
    }
}
