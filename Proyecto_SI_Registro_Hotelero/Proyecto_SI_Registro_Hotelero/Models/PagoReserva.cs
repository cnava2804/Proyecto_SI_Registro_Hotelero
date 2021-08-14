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

        public string PReservaTitular { get; set; }
        public int PReservaCedula { get; set; }
        public int PReservaNumeroTarjeta { get; set; }
        public DateTime PReservaFechaVencimiento { get; set; }
        public int PReservaCodigoTarjeta { get; set; }

        public int ReservaHId { get; set; }
        [ForeignKey("ReservaHId")]
        public ReservaHabitacion ReservaHabitacion { get; set; }


    }
}
