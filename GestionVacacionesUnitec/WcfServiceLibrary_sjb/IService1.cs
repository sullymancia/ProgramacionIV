using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary_sjb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        void agregarUsuario(string talentoH, string correo, string password, string nombre1, string nombre2, string apellido1, string apellido2, string fechaIngreso, string fechaCreacion, bool activo);

        [OperationContract]
        Usuario LogInUsuario(string email , string password);

        [OperationContract]
        int LogIn2(string email, string password);

        [OperationContract]
        void agregarDepartamento(string ID, string descripcion, bool activo);

        [OperationContract]
        void agregarRol(string ID, string descripcion, bool activo);

        [OperationContract]
        void Rol_Usuario(string ID_rol, string ID_permiso);

        [OperationContract]
        void Usuario_Departamento(string Talento_Humano, string ID_departamento);

        [OperationContract]
        void Usuario_Rol(string Talento_Humano, string ID_rol);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServiceLibrary_sjb.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class Usuario
    {
        public int talento_humano { get; set; }
        public string email { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public System.DateTime fecha_ingreso { get; set; }
        public System.DateTime fecha_creacion { get; set; }
        public string password { get; set; }
        public bool activo { get; set; }
    }
}
