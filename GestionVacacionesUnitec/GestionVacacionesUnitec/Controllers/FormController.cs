using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using GestionVacacionesUnitec.ServiceReference1;

namespace GestionVacacionesUnitec.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewCrearUsuario()
        {
            return View("CrearUsuario");
        }

        public ActionResult ViewCrearDepartamento()
        {
            return View("CrearDepartamento");
        }

        public ActionResult ViewCrearRol()
        {
            return View("CrearRol");
        }

        public RedirectToRouteResult crearUser(string talentoH, string correo, string password, string nombre1, string nombre2, string apellido1, string apellido2, string fechaIngreso, string fechaCreacion, string activo)
        {
            Service1Client test = new Service1Client();
            bool estaActivo;
            int numero = Int32.Parse(activo);
            if (numero == 0)
                estaActivo = false;
            else
                estaActivo = true;
            test.agregarUsuario(talentoH, correo, password, nombre1, nombre2, apellido1, apellido2, fechaIngreso, fechaCreacion, estaActivo);
            test.Close();
            return RedirectToAction("Index","Home");
        }
        public RedirectToRouteResult crearDepartamento(string ID, string descripcion, string activo)
        {
            Service1Client test = new Service1Client();
            bool estaActivo;
            int numero = Int32.Parse(activo);
            if (numero == 0)
                estaActivo = false;
            else
                estaActivo = true;
            test.agregarDepartamento(ID, descripcion, estaActivo);
            test.Close();
            return RedirectToAction("Index", "Home");
        }

        public RedirectToRouteResult crearRol(string ID, string descripcion, string activo)
        {
            Service1Client test = new Service1Client();
            bool estaActivo;
            int numero = Int32.Parse(activo);
            if (numero == 0)
                estaActivo = false;
            else
                estaActivo = true;
            test.agregarRol(ID, descripcion, estaActivo);
            test.Close();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult getDepartamentos()
        {
            Service1Client test = new Service1Client();
            List<tbl_departamento> departamentos = test.ListaDeDepartamentos().ToList();

            return Json(new
            {
                /*name = currentUser.Primer_Nombre,
                lastName = currentUser.Primer_Apellido,
                email = currentUser.Email*/
            });
        }

        [HttpGet]
        public ActionResult getRoles()
        {
            Service1Client test = new Service1Client();
            List<tbl_roles> roles = test.ListaDeRoles().ToList();

            return Json(new
            {
                /*name = currentUser.Primer_Nombre,
                lastName = currentUser.Primer_Apellido,
                email = currentUser.Email*/
            });
        }
    }
}