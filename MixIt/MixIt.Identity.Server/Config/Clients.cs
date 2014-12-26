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
                   
                }
            };
        }
    }
}