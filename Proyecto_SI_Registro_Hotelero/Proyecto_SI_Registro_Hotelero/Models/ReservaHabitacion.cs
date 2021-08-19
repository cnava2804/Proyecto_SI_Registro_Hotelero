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

        [Display(Name = "Nombre del Huésped")]
        public string ReservaNombre { get; set; }

        [Display(Name = "Apellido del Huésped")]
        public string ReservaApellido { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Display(Name = "Fecha de Salida")]
        public DateTime FechasSalida { get; set; }

        public int Dias
        {
            get
            {
                return Convert.ToInt32((FechasSalida.Date - FechaIngreso.Date).TotalDays);
            }
        }

        [Display(Name = "Número de Habitación")]
        public int HabitacionId { get; set; }
        [ForeignKey("HabitacionId")]
        public Habitacion Habitacion { get; set; }

        public IEnumerable<PagoReserva> PagoReservas { get; set; }

    }
}
