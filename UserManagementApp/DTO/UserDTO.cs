using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagementApp.DTO
{
    public class UserDTO
    {
        private string userGitHub;

        public string UserGitHub
        {
            get { return this.userGitHub; }
            set { this.userGitHub = value; }
        }
    }
}