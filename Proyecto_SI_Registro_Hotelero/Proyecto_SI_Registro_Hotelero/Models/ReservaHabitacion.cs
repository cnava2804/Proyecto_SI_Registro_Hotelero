using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_SI_Registro_Hotelero.Models
{
    public class ReservaHabitacion
    {
        [Key]
        public int ReservaHId { get; set; }
        
        public string ReservaNombre { get; set; }
        public string ReservaApellido { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechasSalida { get; set; }
        public int ClienteId { get; set; }
        public int HabitacionId { get; set; }
        [ForeignKey("HabitacionId")]
        public Habitacion Habitacion { get; set; }

        public IEnumerable<PagoReserva> PagoReservas { get; set; }

    }
}
