using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Ef;
using BrockAllen.MembershipReboot.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thinktecture.IdentityManager;
using Thinktecture.IdentityManager.MembershipReboot;

namespace MixIt.Identity.Server.Config
{
    public class MembershipRebootIdentityManagerFactory
    {
        static MembershipRebootConfiguration<RelationalUserAccount> config;
        static MembershipRebootIdentityManagerFactory()
        {
            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<DefaultMembershipRebootDatabase, BrockAllen.MembershipReboot.Ef.Migrations.Configuration>());

            config = new MembershipRebootConfiguration<RelationalUserAccount>();
            config.PasswordHashingIterationCount = 5000;
            config.RequireAccountVerification = false;
        }

        string connString;
        public MembershipRebootIdentityManagerFactory(string connString)
        {
            this.connString = connString;
        }
        
        public IIdentityManagerService Create()
        {
            var db = new DefaultMembershipRebootDatabase(this.connString);
            var userrepo = new DefaultUserAccountRepository(db);
            var usersvc = new UserAccountService<RelationalUserAccount>(config, userrepo);
            
            var grprepo = new DefaultGroupRepository(db);
            var grpsvc = new GroupService<RelationalGroup>(config.DefaultTenant, grprepo);
            
            var svc = new MembershipRebootIdentityManagerService<RelationalUserAccount, RelationalGroup>(usersvc, userrepo, grpsvc, grprepo);
            return new DisposableIdentityManagerService(svc, db);
        }
    }
}