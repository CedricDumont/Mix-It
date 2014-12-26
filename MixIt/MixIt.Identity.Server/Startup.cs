using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using MixIt.Identity.Server.Config;
using Owin;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Thinktecture.IdentityServer.Core;
using Thinktecture.IdentityServer.Core.Configuration;
using Thinktecture.IdentityServer.Core.Logging;

[assembly: OwinStartup(typeof(MixIt.Identity.Server.Startup))]

namespace MixIt.Identity.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.Map("/admin", adminApp =>
            {
                var factory = new MembershipRebootIdentityManagerFactory("MyIdentityDb");
                adminApp.UseIdentityManager(new Thinktecture.IdentityManager.IdentityManagerConfiguration()
                {
                    IdentityManagerFactory = factory.Create
                });
            });

            app.Map("/identity", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Identity Server",
                    IssuerUri = "https://idsrv3/mixit",
                    SigningCertificate = LoadCertificate(),

                    Factory = Factory.Configure("MyIdentityDb"),

                    CorsPolicy = CorsPolicy.AllowAll
                });
            });

        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\bin\Config\MixItTest.pfx", AppDomain.CurrentDomain.BaseDirectory), "IAmAPassword");
        }
    }
}