
using BrockAllen.MembershipReboot;
using MixIt.WebApi.Entities;
using MixIt.WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MixIt.WebApi.Controllers
{
    public class RegisterController : ApiController
    {
        UserAccountService<CustomUserAccount> userAccountService;

        public RegisterController(UserAccountService<CustomUserAccount> userAccountService)
        {
            this.userAccountService = userAccountService;
        }

        [HttpPost]
        [Route("api/account/create")]
        public IHttpActionResult RegisterAccount(RegisterInputModel model)
        {
            try
            {
                var account = this.userAccountService.CreateAccount(model.Username, model.Password, model.Email);
            }
            catch (ValidationException vex)
            {
                throw vex;
            }

            return Ok();
        }
    }
}
