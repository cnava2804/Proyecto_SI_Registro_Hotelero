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
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Precio")]
        public decimal HabitacionPrecio { get; set; }


        public int TipoHId { get; set; }
        [ForeignKey("TipoHId")]

        [Display(Name = "Tipo de Habitación")]
        public TipoHabitacion TipoHabitacion { get; set; }
       
        public int PisoHId { get; set; }
        [ForeignKey("PisoHId")]

        [Display(Name = "Piso")]
        public PisoHabitacion PisoHabitacion { get; set; }

       
        public int EstadoHId { get; set; }
        [ForeignKey("EstadoHId")]

        [Display(Name = "Estado")]
        public EstadoHabitacion EstadoHabitacion { get; set; }
        public IEnumerable<ReservaHabitacion> Reservahabitaciones { get; set; }
    }
}
