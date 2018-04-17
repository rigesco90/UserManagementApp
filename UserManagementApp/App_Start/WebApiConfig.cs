﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UserManagementApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{userGitHub}",
                defaults: new { userGitHub = RouteParameter.Optional }
            );
        }
    }
}
