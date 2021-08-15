using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_SI_Registro_Hotelero.Models
{
    public class PagoReserva
    {
        [Key]
        public int PReservaId { get; set; }

        [Display(Name = "Nombre")]
        public string PReservaTitular { get; set; }

        [Display(Name = "Número de Cédula")]
        public string PReservaCedula { get; set; }

        [Display(Name = "Número de Tarjeta")]
        public string PReservaNumeroTarjeta { get; set; }

        [Display(Name = "Fecha Vecimiento")]
        public int PReservaFechaVencimiento { get; set; }

        [Display(Name = "Código Tarjeta")]
        public int PReservaCodigoTarjeta { get; set; }

        public int ReservaHId { get; set; }
        [ForeignKey("ReservaHId")]
        public ReservaHabitacion ReservaHabitacion { get; set; }


    }
}
