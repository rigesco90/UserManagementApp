using System;
using System.Collections.Generic;
using UserManagementApp.DAO;
using UserManagementApp.Models;
using MySql.Data.MySqlClient;
using UserManagementApp.Utils;
using UserManagementApp.DAOConstantsUser;

namespace UserManagementApp.DAOImplements
{
    public class UserDAOImplements : IUserDAO
    {
        private MySqlConnection conn = ConectionDBUtil.GetConnection();

        public string AddUser(User user)
        {
            string answer = null;
            try
            {
                if(null == user.FullName)
                {
                    user.FullName = user.UserGitHub;
                }

                string query = ConstantsDaoUser.addUser + "('" + user.FullName + "','" + user.UserGitHub + "','" + user.UrlImage + "')";
                MySqlCommand comand = new MySqlCommand(query, conn);                
                comand.ExecuteNonQuery();
                return answer = "User created";
            }
            catch(Exception e)
            {
                return answer = "Error creating user.";
            }
            
        }

        public bool ExistUser(User user)
        {
            try
            {
                MySqlCommand comand = new MySqlCommand(ConstantsDaoUser.findByUserGitHub + "'"+user.UserGitHub+"'", conn);
                MySqlDataReader myreader = comand.ExecuteReader();
                while (myreader.Read())
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return true;
            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = null;
            try
            {
                users = new List<User>();
                User user = null;
                MySqlCommand comand = new MySqlCommand(ConstantsDaoUser.findAll, conn);
                MySqlDataReader myreader = comand.ExecuteReader();

                while (myreader.Read())
                {
                    user = new User();
                    user.Id = myreader.GetInt32(0);
                    user.FullName = myreader.GetString(1);
                    user.UserGitHub = myreader.GetString(2);
                    user.UrlImage = myreader.GetString(3);

                    users.Add(user);
                }
                return users;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return users;
        }

        public User GetUserById(User user)
        {
            throw new NotImplementedException();
        }
    }
}