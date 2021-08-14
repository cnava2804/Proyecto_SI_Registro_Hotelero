using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_SI_Registro_Hotelero.Models
{
    public class EstadoHabitacion
    {
        [Key]
        public int EstadoHId { get; set; }
        public string Estado { get; set; }

        public IEnumerable<Habitacion> Habitaciones { get; set; }
    }
}
