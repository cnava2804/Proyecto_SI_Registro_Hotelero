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

        [Display(Name = "Nombre Completo")]
        public string PReservaFullName { get; set; }

        [Display(Name = "Email")]
        public string PReservaCorreo { get; set; }

        [Display(Name = "Nombre de la Targeta")]
        public string PReservaTitular { get; set; }

        [Display(Name = "Número de Cédula")]
        public string PReservaCedula { get; set; }

        [Display(Name = "Número de la Tarjeta")]
        public string PReservaNumeroTarjeta { get; set; }

        [Display(Name = "Fecha Vecimiento")]
        public DateTime PReservaFechaVencimiento { get; set; }

        [Display(Name = "Código Tarjeta")]
        [CreditCard(ErrorMessage ="Tarjeta Invalida")]
        public string PReservaCodigoTarjeta { get; set; }

        //public int Total
        //{
        //    get
        //    {
        //        return Convert.ToInt32(ReservaHabitacion.Dias * 150);
        //    }
        //}


        public int ReservaHId { get; set; }
        [ForeignKey("ReservaHId")]
        public ReservaHabitacion ReservaHabitacion { get; set; }


    }
}
