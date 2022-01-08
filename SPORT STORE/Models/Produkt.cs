using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPORT_STORE.Models
{
    public class Produkt
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Emri Produktit")]
        [Required(ErrorMessage = "Fusha Emri Produktit duhet plotesuar.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Vendosni nje emer ndermjet gjatesise 3 dhe 50 karaktere")]
        public string Emri { get; set; }

        [Required(ErrorMessage = "Fusha Pershkrimi duhet plotesuar.")] 
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Pershkrimi duhet te kete 10 dhe 100 karaktere")]
        [DataType(DataType.MultilineText)]
        public string Pershkrimi { get; set; }

        [Required(ErrorMessage = "Fusha Cmimi duhet plotesuar.")]
        [Range(0.10, 10000, ErrorMessage = "Vendosni nje cmim ndermjet 0.10 dhe 10000.00")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Cmimi { get; set; }

        public string imazh { get; set; }

        public int? KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }

        public int InventarID { get; set; }
        public virtual Inventar Inventar { get; set; }

        public virtual ICollection<Shporta> Shportas { get; set; }
    }
}