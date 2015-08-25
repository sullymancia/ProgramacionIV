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
            Usuario user = test.LogInUsuario(email, password);
            test.Close();
            if (user != null)
            {
                Session["Secion"] = user;
                return RedirectToAction("Index", "LoginTest");
            }
            else
                return RedirectToAction("Index");
        }
        public RedirectToRouteResult crearUser(string talentoH, string correo, string password, string nombre1, string nombre2, string apellido1, string apellido2, string fechaIngreso, string fechaCreacion, bool activo)
        {
            Service1Client test = new Service1Client();
            test.agregarUsuario(talentoH, correo, password, nombre1, nombre2, apellido1, apellido2, fechaIngreso, fechaCreacion, activo);
            test.Close();
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult crearDepartamento(string ID, string descripcion, bool activo)
        {
            Service1Client test = new Service1Client();
            test.agregarDepartamento(ID, descripcion, activo);
            test.Close();
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult crearRol(string ID, string descripcion, bool activo)
        {
            Service1Client test = new Service1Client();
            test.agregarRol(ID, descripcion, activo);
            test.Close();
            return RedirectToAction("Index");
        }
    }
}