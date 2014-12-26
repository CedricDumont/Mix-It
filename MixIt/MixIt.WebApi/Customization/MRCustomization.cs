using BrockAllen.MembershipReboot.Ef;
using BrockAllen.MembershipReboot.Relational;
using MixIt.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixIt.WebApi.Customization
{

    public class CustomDb : MembershipRebootDbContext<CustomUserAccount>
    {
        public CustomDb()
            : base("MyIdentityDb")
        {
        }
    }

    public class CustomUserAccountRepository : DbContextUserAccountRepository<CustomDb, CustomUserAccount>
    {
        public CustomUserAccountRepository(CustomDb db)
            : base(db)
        {
        }
    }
}