using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsHappening.Auth;

namespace WhatsHappening.Web.Areas.Backoffice.Models.Account
{
    public class AccountListModel
    {
        public List<ApplicationUser> ApplicationUserList { get; set; }
    }
}