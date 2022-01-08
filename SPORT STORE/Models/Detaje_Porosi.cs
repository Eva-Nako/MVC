using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPORT_STORE.Models
{
    public class Detaje_Porosi
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Sasia { get; set; }

        public int PorosiID { get; set; }
        public virtual Porosi Porosi { get; set; }

        public int ProduktID { get; set; }
        public virtual Produkt Produkt { get; set; }
    }
}