using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;
using Atlantis.Framework.Entity.Interface.SelfTracking;
using System.Text.RegularExpressions;

namespace Atlantis.Framework.CampaignManagerData.Interface
{
    public class KeyValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isValid = true;            
            string valueAsString = value as string;

            if (valueAsString != null)
            {                
                Regex r = new Regex(@"\s+");
                string replacedString = r.Replace(valueAsString, @"");

                if (valueAsString != replacedString)
                    isValid = false;                
            }

            return (isValid == true ? ValidationResult.Success : new ValidationResult("Value entered for Campaign Number is not valid. Whitespace not allowed"));
        }
    }
}
