using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserManagementApp.BO;
using UserManagementApp.DTO;
using UserManagementApp.Models;

namespace UserManagementApp.Controllers
{
    public class UserController : ApiController
    {
        private IUserBO IUserBO;
        private static readonly HttpClient client = new HttpClient();
        
        public UserController(IUserBO userBO)
        {
            this.IUserBO = userBO;
        }

        private List<User> users;

        public HttpResponseMessage GetAllUsers()
        {
            try
            {
                users = IUserBO.FindAllUsers();
                if(null != users)
                {
                    return Request.CreateResponse(HttpStatusCode.Found, users);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
                }
                
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
            }
           
            
        }

        public HttpResponseMessage GetUser(string userGitHub)
        {
            try
            {
                users = IUserBO.FindAllUsers();
                var user = users.FirstOrDefault((u) => u.UserGitHub == userGitHub);
                if (user != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Found, user);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data found");
                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error");
            }
           
        }       

        public HttpResponseMessage PostUserGit([FromBody]UserDTO user)
        {
            try
            {
                if(user != null)
                {
                    string rta = IUserBO.AddUser(user);
                    var resp = Request.CreateResponse(HttpStatusCode.Created, rta);
                    resp.Headers.Location = Request.RequestUri;
                    return resp;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User null");
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Data not inserted");
            }
        }
    }
}
