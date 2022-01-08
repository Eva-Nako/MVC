using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPORT_STORE.Models
{
    public class Porosi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Sasia { get; set; }

        [Required]
        public string Adresa { get; set; }

        [Phone]
        [Required]
        public string Telefon { get; set; }

        
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Detaje_Porosi> Detaje_Porosis { get; set; }
       
    }
}