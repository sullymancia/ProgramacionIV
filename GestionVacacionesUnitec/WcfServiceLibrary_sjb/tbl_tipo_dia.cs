//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceLibrary_sjb
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_tipo_dia
    {
        public tbl_tipo_dia()
        {
            this.tbl_calendario = new HashSet<tbl_calendario>();
        }
    
        public int tipo_dia_id { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<tbl_calendario> tbl_calendario { get; set; }
    }
}
