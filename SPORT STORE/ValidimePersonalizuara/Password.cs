using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SPORT_STORE.Models;




namespace SPORT_STORE.ValidimePersonalizuara
{
    public class Password : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pass = value.ToString();
            string Message;
            if (pass!=null)
            {
                if (pass.Contains("!") || pass.Contains("@") || pass.Contains("#") || pass.Contains("$") || pass.Contains("^") || pass.Contains("&"))
                {
                    return ValidationResult.Success;
                }
                    
                else
                {
                    Message="Password duhet te permbaje nje karakter special!";
                   return new ValidationResult(Message);
                }

            }
            else
            {
                Message = "Plotesoni fushen!";
                return new ValidationResult(Message);
            }

            
        }

    }
}