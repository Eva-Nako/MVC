using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SPORT_STORE.ValidimePersonalizuara
{
    public class EmriPersonalizuar:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string emri = value.ToString();
            string Message;
            if (emri != null)
            {
                if (emri.Contains("!@#$%^&*"))
                {
                    Message = "Emri nuk duhet te permbaje karaktere speciale!";
                    return new ValidationResult(Message);
                }

                else
                {
                    return ValidationResult.Success;
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