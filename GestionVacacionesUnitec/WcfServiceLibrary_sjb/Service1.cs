using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary_sjb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void agregarUsuario(string talentoH, string correo, string password, string nombre1, string nombre2, string apellido1, string apellido2, string fechaIngreso, string fechaCreacion, bool activo)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            tbl_usuarios newUsuario = new tbl_usuarios();
            newUsuario.talento_humano = Int32.Parse(talentoH);
            newUsuario.password = password;
            newUsuario.email = correo;
            newUsuario.primer_nombre = nombre1;
            newUsuario.segundo_nombre = nombre2;
            newUsuario.primer_apellido = apellido1;
            newUsuario.segundo_apellido = apellido2;
            newUsuario.fecha_ingreso = Convert.ToDateTime(fechaIngreso);
            newUsuario.fecha_creacion = Convert.ToDateTime(fechaCreacion);
            newUsuario.activo = activo;

            ent.tbl_usuarios.Add(newUsuario);
            ent.SaveChanges();
        }

        public Usuario LogInUsuario(string email, string password)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            //tbl_usuarios newUsuario = new tbl_usuarios();

            var query = (from u in ent.tbl_usuarios
                        where u.email == email && u.password == password
                        select u).FirstOrDefault();

            if(query == null)
                return null;

            Usuario user = new Usuario()
            {
                activo = query.activo,
                email = query.email,
                fecha_creacion = query.fecha_creacion,
                fecha_ingreso = query.fecha_ingreso,
                primer_apellido = query.primer_apellido,
                primer_nombre = query.primer_nombre,
                segundo_apellido = query.segundo_apellido,
                segundo_nombre = query.segundo_apellido,
                talento_humano = query.talento_humano
            };

            //newUsuario = query;

            return user; 
        }

        public void agregarDepartamento(string ID, string descripcion, bool activo)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            tbl_departamento newDepartamento = new tbl_departamento();
            newDepartamento.departamentoid = Int32.Parse(ID);
            newDepartamento.descripcion = descripcion;
            newDepartamento.activo = activo;

            ent.tbl_departamento.Add(newDepartamento);
            ent.SaveChanges();
        }

        public void agregarRol(string ID, string descripcion, bool activo)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            tbl_roles newRol = new tbl_roles();
            newRol.rolesid = Int32.Parse(ID);
            newRol.descripcion = descripcion;
            newRol.activo = activo;

            ent.tbl_roles.Add(newRol);
            ent.SaveChanges();
        }

        public void Rol_Permiso(string ID_rol, string ID_permiso)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
        }

        public void Usuario_Departamento(string Talento_Humano, string descripcion_departamento)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            int _Talento_Humano = Int32.Parse(Talento_Humano);
            var query = (from u in ent.tbl_usuarios
                         where u.talento_humano == _Talento_Humano
                         select u).FirstOrDefault();
            int _descripcion_departamento = Int32.Parse(descripcion_departamento);
            var query2 = (from u in ent.tbl_departamento
                          where u.departamentoid == _descripcion_departamento
                          select u).FirstOrDefault();
            tbl_usuarios user = query;
            tbl_departamento departamento = query2;
            user.tbl_departamento.Add(departamento);
            ent.SaveChanges();
        }

        public void Usuario_Rol(string Talento_Humano, string descripcion_rol)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            int _talentoHumano = Int32.Parse(Talento_Humano);
            var query = (from u in ent.tbl_usuarios
                         where u.talento_humano == _talentoHumano
                         select u).FirstOrDefault();
            int _descripcion_rol = Int32.Parse(descripcion_rol);
            var query2 = (from u in ent.tbl_roles
                          where u.rolesid == _descripcion_rol
                         select u).FirstOrDefault();
            tbl_usuarios user = query;
            tbl_roles rol = query2;
            user.tbl_roles.Add(rol);
            ent.SaveChanges();
        }

        public int LogIn2(string email, string password)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();

            var query = (from u in ent.tbl_usuarios
                         where u.email == email && u.password == password
                         select u).FirstOrDefault();

            if (query == null)
                return 0;
            return 1;
        }

        public tbl_usuarios LogInUsuario2(string email, string password)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            var query = (from u in ent.tbl_usuarios
                         where u.email == email && u.password == password
                         select u).FirstOrDefault();

            if (query == null)
                return null;
            return query; 
        }

        public List<tbl_departamento> ListaDeDepartamentos()
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            var query = (from u in ent.tbl_departamento
                         select u).ToList();
            return query;
        }

        public List<tbl_roles> ListaDeRoles()
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            var query = (from u in ent.tbl_roles
                         select u).ToList();
            return query;
        }

        public tbl_roles ListaDeRolesPorUsuario(string talento_humano)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            int numero = Int32.Parse(talento_humano);
            List<string> miListaDeIDs = new List<string>();
            var query = (from u in ent.tbl_usuarios
                         where u.talento_humano == numero
                         select u).FirstOrDefault();
            tbl_usuarios user = query;
            List<tbl_roles> miListaDeRoles = user.tbl_roles.ToList();
            int numeroDeRoles = miListaDeRoles.Count();

            //int penesote = miListaDeRoles.ElementAt(0).rolesid();

            tbl_roles[] miArregloDeRoles = new tbl_roles[numeroDeRoles];
            for(int x=0; x<numeroDeRoles; x++)
            {
                miArregloDeRoles[x] = miListaDeRoles.ElementAt(x);
            }
            return miArregloDeRoles[0];
        }
    }
}
