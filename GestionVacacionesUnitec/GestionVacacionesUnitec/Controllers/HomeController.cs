﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using GestionVacacionesUnitec.ServiceReference1;

namespace GestionVacacionesUnitec.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("DashBoard");
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
        public ActionResult getRolesPorUsuario(string talento_humano)
        {
            Service1Client test = new Service1Client();
            //tbl_roles _roles = test.ListaDeRolesPorUsuario(talento_humano);
            test.Close();
            int numero;

            

            return Json(new
            {
                roles = "place holder"
            });
            
        }
    }
}