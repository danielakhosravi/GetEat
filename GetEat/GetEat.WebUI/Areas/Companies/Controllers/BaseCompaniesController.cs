using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetEat.WebUI.Models;

namespace GetEat.WebUI.Areas.Companies.Controllers
{
    [Authorize(Roles = RoleNames.Customer + "," + RoleNames.Adminstrator)]
    public class BaseCompaniesController : Controller
    {

    }
}