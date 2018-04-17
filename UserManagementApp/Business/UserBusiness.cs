using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using UserManagementApp.BO;
using UserManagementApp.DAO;
using UserManagementApp.DTO;
using UserManagementApp.Models;

namespace UserManagementApp.Business
{
    public class UserBusiness : IUserBO
    {
        private IUserDAO UserDAO;

        private const string address = "https://api.github.com/users/";
        private const string userAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) " +
                                         "AppleWebKit/537.36 (KHTML, like Gecko) " +
                                         "Chrome/58.0.3029.110 Safari/537.36";

        

        public UserBusiness(IUserDAO userDAO)
        {
            this.UserDAO = userDAO;
        }

        public List<User> FindAllUsers()
        {
            return UserDAO.GetAllUsers();
        }

        public User GetUserById(User user)
        {
            throw new NotImplementedException();
        }

        public string AddUser(UserDTO userDTO)
        {
            string answer = null;            
            try
            {
                User user = new User();
                user.UserGitHub = userDTO.UserGitHub;
                if (UserDAO.ExistUser(user))
                {
                    return answer = "The user already exists in the database.";
                }
                else
                {
                    user = GetUserGit(userDTO);
                    return answer = UserDAO.AddUser(user);
                }                
            }
            catch (Exception)
            {
                return answer = "Error when creating user";
            }
        }

        private static User GetUserGit(UserDTO userDTO)
        {
            User user = null;
            try
            {
                WebClient client = new WebClient();
                user = new User();
                client.Headers.Add("user-agent", userAgent);
                string response = client.DownloadString(address + userDTO.UserGitHub);
                dynamic releases = JObject.Parse(response);
                user = UserGitToUserDTO(releases);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en GetUserGit..." + e);
            }
            return user;
        }

        private static User UserGitToUserDTO(dynamic userGit)
        {
            User user = new User();
            user.FullName = userGit.name;
            user.UserGitHub = userGit.login;
            user.UrlImage = userGit.avatar_url;
            return user;
        }
    }
}