using BrockAllen.MembershipReboot;
using MixIt.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixIt.WebApi.App_Start
{
    public class MembershipRebootConfig
    {
        public static MembershipRebootConfiguration<CustomUserAccount> Create()
        {
            var settings = SecuritySettings.Instance;

            var config = new MembershipRebootConfiguration<CustomUserAccount>(settings);

            return config;
        }
    }
}