using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mvc.ResourceExplorer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ResourceView()
        {
            return View("Resource");
        }

        [Authorize]
        public async Task<ActionResult> Resource()
        {
            ViewBag.RetrievedResource = await GetResourceWithId(1);

            return View("Resource");
        }

        [Authorize]
        public async Task<ActionResult> Resource2()
        {
            ViewBag.RetrievedResource = await GetResourceWithId(2);

            return View("Resource");
        }

        [Authorize]
        public async Task<ActionResult> Resource3()
        {
            ViewBag.RetrievedResource = await GetResourceWithId(3);

            return View("Resource");
        }

        private async Task<String> GetResourceWithId(Int32 id)
        {
            var user = User as ClaimsPrincipal;
            var token = user.FindFirst("access_token").Value;

            var client = new HttpClient();
            client.SetBearerToken(token);

            HttpResponseMessage response = await client.GetAsync("http://localhost:14117/resource/" + id);

            return await response.Content.ReadAsStringAsync();
        }

        public ActionResult CheckAuthenticated()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}