using System.Collections.Generic;
using UserManagementApp.DTO;
using UserManagementApp.Models;

namespace UserManagementApp.BO
{
   public interface IUserBO
    {
        List<User> FindAllUsers();

        User GetUserById(User user);

        string AddUser(UserDTO userDTO);
    }
}
