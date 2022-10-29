using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsHappening.Auth;

namespace WhatsHappening.Web.Areas.Backoffice.Models.Account
{
    public class UserRoleEditorModel
    {
        //public List<Tuple<IdentityRole, bool>> Roles { get; set; }
        public MultiSelectList Roles { get; set; }

        
        

    }
}