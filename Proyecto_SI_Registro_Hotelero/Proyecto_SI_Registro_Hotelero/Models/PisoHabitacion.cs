using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_SI_Registro_Hotelero.Models
{
    public class PisoHabitacion
    {
        [Key]
        public int PisoHId { get; set; }
        public string Piso { get; set; }
        public IEnumerable<Habitacion> Habitaciones { get; set; }

    }
}
