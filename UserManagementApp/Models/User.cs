using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagementApp.Models
{
    public class User
    {
        private int id;
        private string userGitHub;
        private string fullName;
        private string urlImage;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string UserGitHub
        {
            get { return this.userGitHub; }
            set { this.userGitHub = value; }
        }

        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }

        public string UrlImage
        {
            get { return this.urlImage; }
            set { this.urlImage = value; }
        }
    }
}