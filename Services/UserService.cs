using CRUD_application_2.Models;
using CRUD_application_2.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_application_2.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>();

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            // You might want to add logic to generate a unique ID for the new user
            _users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                // Update the properties of the existing user
                existingUser.Name = user.Name;
                // Add other properties to update as needed
            }
        }

        public void DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }

        public IList<User> GetUsers()
        {
            return _users;
        }
    }
}