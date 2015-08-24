using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionVacacionesUnitec.ServiceReference1;

namespace GestionVacacionesUnitec.Controllers
{
    public class TestForServiceController : Controller
    {
        // GET: TestForService
        public ActionResult Index()
        {
            return View("TestStartIndex");
        }

        [HttpPost]
        public void LoginValidation(string email, string password)
        {
            Login(email,password);
        }


        public RedirectToRouteResult Login(string email, string password)
        {
            Service1Client test = new Service1Client();
            Usuario user = test.LogInUsuario("lechungo@unitec.edu", "password");
            test.Close();
            if (user != null)
            {
                Session["Secion"] = user;
                return RedirectToAction("Index", "LoginTest");
            }
            else
                return RedirectToAction("Index");
        }

    }
}