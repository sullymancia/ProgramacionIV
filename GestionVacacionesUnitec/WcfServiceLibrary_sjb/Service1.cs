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

        public void agregarUsuario()
        {
            vsystem_sjbEntities ent = new vsystem_sjbEntities();
            tbl_usuarios newUsuario = new tbl_usuarios();

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
    }
}
