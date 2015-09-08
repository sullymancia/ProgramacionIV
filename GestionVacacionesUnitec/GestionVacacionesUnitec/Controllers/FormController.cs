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

        [HttpPost]
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

        [HttpPost]
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

        [HttpPost]
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
        [HttpPost]
        public ActionResult getDepartamentos()
        {
            Service1Client test = new Service1Client();
            List<tbl_departamento> departamentos = test.ListaDeDepartamentos().ToList();
            test.Close();
            string misDepartamentos = "";
            for (int x = 0; x < departamentos.Count; x++)
            {
                if (departamentos.ElementAt(x).activo == true)
                    misDepartamentos += (x > 0) ?
                        "~" + departamentos.ElementAt(x).descripcion : departamentos.ElementAt(x).descripcion;               
            }
                return Json(new
                {
                    serializedData = misDepartamentos
                });
        }

        [HttpGet]
        public ActionResult getRoles()
        {
            Service1Client test = new Service1Client();
            List<tbl_roles> roles = test.ListaDeRoles().ToList();
            test.Close();
            string misRoles = "";
            for (int x = 0; x < roles.Count; x++)
            {
                if (roles.ElementAt(x).activo == true)
                    misRoles = misRoles + "~" + roles.ElementAt(0).descripcion;
            }
            return Json(new
            {
                /*name = currentUser.Primer_Nombre,
                lastName = currentUser.Primer_Apellido,
                email = currentUser.Email*/
            });
        }

        [HttpPost]
        public ActionResult getSession()
        {
            Usuario currentUser = Session["Secion2"] as Usuario;

            return Json(new
            {
                name = currentUser.Primer_Nombre,
                lastName = currentUser.Primer_Apellido,
                email = currentUser.Email,
                talentoHumano = currentUser.Talento_Humano
            });
        }


        [HttpPost]
        public void Usuario_Rol(string Talento_Humano, string descripcion_rol)
        {
            Service1Client test = new Service1Client();
            List<string> miLista = descripcion_rol.Split('~').ToList();

            for (int x = 0; x < miLista.Count; x++)
                test.Usuario_Rol(Talento_Humano, miLista.ElementAt(x));

            test.Close();

        }

        [HttpPost]
        public void Usuario_Departamento(string Talento_Humano, string descripcion_departamento)
        {
            Service1Client test = new Service1Client();
            List<string> miLista = descripcion_departamento.Split('~').ToList();
            for (int x = 0; x < miLista.Count; x++)
            {
                test.Usuario_Departamento(Talento_Humano, miLista.ElementAt(x));
            }
            test.Close();
        }
    }
}