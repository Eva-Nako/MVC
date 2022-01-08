using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPORT_STORE.Models
{
    public class Inventar
    {
        [Key]
        public int ID { get; set; }
        public string Sasia { get; set; }
        public virtual ICollection<Produkt> Produkts { get; set; }
    }
}