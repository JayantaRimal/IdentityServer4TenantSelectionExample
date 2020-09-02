using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.DbContexts;
using IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Quickstart
{
    public class CompanySelectionController : Controller
    {
        private readonly MasterDbContext _db;

        public CompanySelectionController (MasterDbContext db)
        {
            this._db = db;

        }
        public IActionResult Index()
        {
            var currentUserName = User.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value;
            var companyDetail = _db.Companies.Where(x => x.UserId == currentUserName).ToList();

            return View(companyDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Select(Company model)
        {
            Uri uri = new Uri(Request.Headers["Referer"].ToString());
            string ReturnUrl = System.Web.HttpUtility.ParseQueryString(uri.Query)["returnUrl"];

            await HttpContext.SignInAsync(User.Claims.Single(r => r.Type == "sub").Value,
                new System.Security.Claims.Claim("database_name", model.DatabaseName.ToString()));

            return Redirect(ReturnUrl);

        }
    }
}