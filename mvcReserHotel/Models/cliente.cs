//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcReserHotel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            this.reservacion = new HashSet<reservacion>();
        }
    
        public int cod_cliente { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string nacionalidad { get; set; }
        public string procedencia { get; set; }
        public string cui { get; set; }
        public string extendido_en { get; set; }
        public Nullable<int> cod_estado_civil { get; set; }
        public string profesión { get; set; }
    
        public virtual estado_civil estado_civil { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservacion> reservacion { get; set; }
    }
}
