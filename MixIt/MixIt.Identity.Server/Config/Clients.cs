using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thinktecture.IdentityServer.Core.Models;

namespace  MixIt.Identity.Server.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]{
            new Client
                {
                    //Resource Owner Flow Client (our web UI)
                    ClientName = "WebUI",
                    Enabled = true,

                    ClientId = "IdentityWebUI",
                    ClientSecret = "secret",

                    Flow = Flows.ResourceOwner,                    
                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 3600
                   
                },
                new Client
                {
                    ClientName = "Resource Explorer",
                    Enabled = true,

                    ClientId = "ResourceExplorer",
                    ClientSecret = "secret",
                    Flow = Flows.Implicit,
                    
                    ClientUri = "http://www.resExplorer.com",
                
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    
                    RedirectUris = new List<string>
                    {
                        "http://localhost:10071/",
                    },

                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:10071/",
                    },
                    
                    IdentityTokenLifetime = 360,
                    AccessTokenLifetime = 3600
                }
            };
        }
    }
}