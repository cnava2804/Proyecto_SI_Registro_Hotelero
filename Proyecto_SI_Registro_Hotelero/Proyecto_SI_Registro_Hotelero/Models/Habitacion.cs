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

        [Display(Name = "Número Habitación")]
        public string HabitacionNumero { get; set; }


        [Display(Name = "Descripción")]
        public string HabitacionDescripcion { get; set; }


        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C0}")]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Precio")]
        public int HabitacionPrecio { get; set; }

        [Display(Name = "Tipo de Habitación")]
        public int TipoHId { get; set; }
        [ForeignKey("TipoHId")]

        [Display(Name = "Tipo de Habitación")]
        public TipoHabitacion TipoHabitacion { get; set; }


        [Display(Name = "Piso")]
        public int PisoHId { get; set; }
        [ForeignKey("PisoHId")]

        [Display(Name = "Piso")]
        public PisoHabitacion PisoHabitacion { get; set; }


        [Display(Name = "Estado")]
        public int EstadoHId { get; set; }
        [ForeignKey("EstadoHId")]

        [Display(Name = "Estado")]
        public EstadoHabitacion EstadoHabitacion { get; set; }
        public IEnumerable<ReservaHabitacion> Reservahabitaciones { get; set; }
    }
}
