using System;
using System.Collections.Generic;
using UserManagementApp.Models;

namespace UserManagementApp.DAO
{
   public interface IUserDAO
    {
        List<User> GetAllUsers();

        User GetUserById(User user);

        Boolean ExistUser(User user);

        string AddUser(User user);

    }
}
