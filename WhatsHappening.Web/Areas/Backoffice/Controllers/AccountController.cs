using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHappening.Auth;
using Microsoft.AspNet.Identity.Owin;
using WhatsHappening.Web.Areas.Backoffice.Models.Account;

namespace WhatsHappening.Web.Areas.Backoffice.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            WhatsHappening.Web.Areas.Backoffice.Models.Account.AccountListModel m = new Models.Account.AccountListModel();
            m.ApplicationUserList = userManager.Users.ToList();
            return View(m);
        }


        public ActionResult Edit(string id)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var usr = userManager.Users.SingleOrDefault(p => p.Id == id);
            AccountEditModel model = new AccountEditModel();
            model.ApplicationUser = usr;
            return View(model);
        }

    }
}