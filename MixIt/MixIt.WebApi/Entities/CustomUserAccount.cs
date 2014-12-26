using BrockAllen.MembershipReboot.Ef;
using BrockAllen.MembershipReboot.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MixIt.WebApi.Entities
{
    public class CustomUserAccount : RelationalUserAccount
    {
        //Be carrefull to put the property as virtual otherwise you'll get the following error:
        //An exception of type 'System.InvalidOperationException' occurred in EntityFramework.dll but was not handled in user code
        //Additional information: The source query for this EntityCollection or EntityReference cannot be returned when the related object is in either an added state or a detached state and was not originally retrieved using the NoTracking merge option.

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }

}