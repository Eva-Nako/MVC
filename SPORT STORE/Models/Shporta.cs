using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPORT_STORE.Models
{
    public class Shporta
    {
        [Key]
        public int ID { get; set;}
        public int Sasia { get; set; }
        public int? ProduktID { get; set; }
        public virtual Produkt Produkt { get; set; }
        public string IdPerdorues { get; set; }
    }

}