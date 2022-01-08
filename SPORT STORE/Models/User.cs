using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SPORT_STORE.ValidimePersonalizuara;

namespace SPORT_STORE.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Fusha Emri duhet plotesuar")]
        [EmriPersonalizuar]
        public string Emri { get; set; }

        [Required(ErrorMessage = "Fusha Mbiemri duhet plotesuar")]
        public string Mbiemri { get; set; }

        [Required(ErrorMessage = "Fusha Email duhet plotesuar")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Fusha Password duhet plotesuar")]
        [Password]
        public string Password { get; set; }

        [Required(ErrorMessage = "Fusha Numer Telefoni duhet plotesuar")]
        [Phone]
        public string NrTelefon { get; set; }

        public string Tipi { get; set; }

        public virtual ICollection<Porosi> Porosis { get; set; }
    }
}