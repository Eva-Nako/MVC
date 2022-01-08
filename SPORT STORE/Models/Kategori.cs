using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPORT_STORE.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fusha Emri Kategorise duhet plotesuar.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Vendosni nje emer ndermjet gjatesise 3 dhe 50 karaktere")]
        [Display(Name = "Emri kategorise")]
        public string Emri { get; set; }

        public virtual ICollection<Produkt> Produkts { get; set; }
    }
}