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
                password = query.password,
                primer_apellido = query.primer_apellido,
                primer_nombre = query.primer_nombre,
                segundo_apellido = query.segundo_apellido,
                segundo_nombre = query.segundo_apellido,
                talento_humano = query.talento_humano
            };
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

        public void Rol_Usuario(string ID_rol, string ID_permiso)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
        }

        public void Usuario_Departamento(string Talento_Humano, string ID_departamento)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
        }

        public void Usuario_Rol(string Talento_Humano, string ID_rol)
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
        }
    }
}
