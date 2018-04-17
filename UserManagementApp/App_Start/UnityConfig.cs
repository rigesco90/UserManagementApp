using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using UserManagementApp.BO;
using UserManagementApp.Business;
using UserManagementApp.DAO;
using UserManagementApp.DAOImplements;

namespace UserManagementApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IUserBO, UserBusiness>();
            container.RegisterType<IUserDAO, UserDAOImplements>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}