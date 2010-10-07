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
    public class ManyToManyRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string validationMessage = string.Empty;

            if (value.GetType().GetProperty("Item").PropertyType.Name == "CampaignCompanyMap")
            {
                TrackableCollection<CampaignCompanyMap> tc = (TrackableCollection<CampaignCompanyMap>)value;
                if (tc.Count == 0)
                    validationMessage = string.Format("{0} is a required field.", (validationContext.DisplayName != string.Empty ? validationContext.DisplayName : validationContext.MemberName));                
            }            
            
            return (validationMessage == string.Empty ? ValidationResult.Success : new ValidationResult(validationMessage));
        }
    }
}
