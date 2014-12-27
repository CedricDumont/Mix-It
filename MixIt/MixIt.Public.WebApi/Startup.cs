using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Thinktecture.IdentityServer.v3.AccessTokenValidation;

[assembly: OwinStartup(typeof( MixIt.Public.WebApi.Startup))]

namespace   MixIt.Public.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            #region authentication part

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44305/identity",
                RequiredScopes = new[] { "publicApi" }
            });
            
            #endregion

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);
        }
    }
}