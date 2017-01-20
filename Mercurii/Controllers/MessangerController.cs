using BAL.Interface;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mercurii.Controllers
{
    public class MessangerController : Controller
    {
        private IUserManager userManager;
        public MessangerController(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        // GET: Messanger
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string username)
        {
            List<UserDTO> users = userManager.SearchByName(username);

            return View(users);
        }
    }
}