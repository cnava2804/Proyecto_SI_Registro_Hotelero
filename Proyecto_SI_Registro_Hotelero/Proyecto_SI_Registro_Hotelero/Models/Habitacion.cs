using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_SI_Registro_Hotelero.Models
{
    public class Habitacion
    {
        [Key]
        public int HabitacionId { get; set; }
        public string HabitacionNumero { get; set; }
        public string HabitacionDescripcion { get; set; }
        public int HabitacionPrecio { get; set; }
        public int TipoHId { get; set; }
        [ForeignKey("TipoHId")]
        public TipoHabitacion TipoHabitacion { get; set; }
        public int PisoHId { get; set; }
        [ForeignKey("PisoHId")]
        public PisoHabitacion PisoHabitacion { get; set; }
        public int EstadoHId { get; set; }
        [ForeignKey("EstadoHId")]
        public EstadoHabitacion EstadoHabitacion { get; set; }
        public IEnumerable<ReservaHabitacion> Reservahabitaciones { get; set; }
    }
}
