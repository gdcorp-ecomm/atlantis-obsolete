using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Web.UI.WebControls;

namespace Atlantis.Framework.CampaignManagerData.Interface
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ValuesListAttribute : Attribute
    {
        public ValuesListAttribute() { }

        public ValuesListAttribute(String values)
        {
            var items = values.Split(new char[] { ',', ';' });
            Values = (from item in items
                      select new ListItem()
                      {
                          Text = item,
                          Value = item
                      }).ToArray();
        }

        public ListItem[] Values { get; set; }
    }
}

