using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;
using Atlantis.Framework.Entity.Interface.SelfTracking;

namespace Atlantis.Framework.CampaignManagerData.Interface
{
    public class MercuryItemValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isValid = true;            
            string valueAsString = value as string;

            if (valueAsString != null)
            {
                string[] qcItems = valueAsString.Split(',');
                foreach (string item in qcItems)
                {
                    try
                    {
                        int qcNumber = int.Parse(item);
                        if (qcNumber < 0)
                            isValid = false;                        
                    }
                    catch
                    {
                        isValid = false;
                    }
                }
            }

            return (isValid == true ? ValidationResult.Success : new ValidationResult("Value entered for Mercury ID(s) field is not valid"));
        }
    }
}
