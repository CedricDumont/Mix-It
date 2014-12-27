
using MixIt.Public.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MixIt.Public.WebApi.Controllers
{
   
    [RoutePrefix("resource")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class ResourceController : ApiController
    {

       [Route("{id}")]
        public IHttpActionResult Get(long id)
        {
            var res = from element in Resource.GetDummyList() where element.Id == id select element;

            if (res == null)
            {
                return NotFound();
            }

            return Json(res);
        }
    }
}