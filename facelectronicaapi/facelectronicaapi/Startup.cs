using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Web.Http;
using FacElectronicaApi.Provider;

[assembly: OwinStartup(typeof(FacElectronicaApi.Startup))]
namespace FacElectronicaApi
{
    /// <summary>
    /// Clase utilizada para realizar la configuración inicial de la aplicación
    /// Aqui se establece la configuración de las rutas y autenticación
    /// 
    /// NuGet Packages necesarios para Owin OAuth
    ///     Microsoft.AspNet.WebApi.Owin
    ///     Microsoft.Owin.Host.SystemWeb
    ///     
    ///     Microsoft.AspNet.Identity.Owin
    ///     Microsoft.AspNet.Identity.EntityFramework    Si se desea utilizar con Entity Framework
    ///     Microsoft.Owin.Security.OAuth
    ///     Microsoft.Owin.Cors
    ///     
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Se establece la configuración inicial de la aplicación
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigureOAuth(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        /// <summary>
        /// Se configura el administrador de token de Autenticación
        /// </summary>
        /// <param name="sender"></param>
        public void ConfigureOAuth(object sender)
        {
            IAppBuilder app = (IAppBuilder)sender;

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationServerProvider()
            };

            //Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}