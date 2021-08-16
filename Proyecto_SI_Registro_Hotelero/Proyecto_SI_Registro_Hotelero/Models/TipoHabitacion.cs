using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_SI_Registro_Hotelero.Models
{
    public class TipoHabitacion
    {
        [Key]
        public int TipoHId { get; set; }

        [Display (Name = "Tipo de Habitación")]
        public string TipoDescripcion { get; set; }
        public IEnumerable<Habitacion> Habitaciones { get; set; }

    }
}
