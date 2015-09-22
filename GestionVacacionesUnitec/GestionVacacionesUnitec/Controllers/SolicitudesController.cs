using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using GestionVacacionesUnitec.ServiceReference1;

namespace GestionVacacionesUnitec.Controllers
{
    public class SolicitudesController : Controller
    {
        // GET: Solicitudes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CrearSolicitud()
        {
            return View("CrearSolicitud");
        }



        /*public RedirectToRouteResult crearVacacionSolicitud(string talento_humano, string year, string fecha_entrada, 
                                                            string fecha_salida, string dias_solicitados, string fecha_solicitud, 
                                                            string fecha_aprobacion, string estatusID)*/


        [HttpPost]
        public RedirectToRouteResult crearVacacionSolicitud()
        {
            Service1Client test = new Service1Client();
            //test.agregarVacaciones(talento_humano, year, fecha_entrada, fecha_salida, dias_solicitados, fecha_solicitud, fecha_aprobacion, estatusID);
            test.agregarVacaciones("21251122", "2", "2/3/2011", "2/3/2012",
                "365", "3251995", "3/24/1994", "1");
            test.Close();
            return RedirectToAction("Index", "Home");
        }
    }
}