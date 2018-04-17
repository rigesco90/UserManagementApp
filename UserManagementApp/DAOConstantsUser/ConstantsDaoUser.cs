namespace UserManagementApp.DAOConstantsUser
{
    public class ConstantsDaoUser
    {
       public static string findAll = "SELECT * FROM USER ORDER BY idUser";
       public static string findByUserGitHub = "SELECT * FROM USER WHERE USER.userGitHub = ";
       public static string addUser = "INSERT INTO USER (fullName, userGitHub, urlImageGitHub) VALUES";
    }
}