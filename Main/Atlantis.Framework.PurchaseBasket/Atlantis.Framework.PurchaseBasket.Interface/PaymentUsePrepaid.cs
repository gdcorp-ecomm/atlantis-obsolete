using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.PurchaseBasket.Interface
{
  public class PaymentUsePrepaid : PaymentElement
  {
    public override string ElementName
    {
      get { return "PrepaidPayment"; }
    }

    public int Amount
    {
      get { return GetIntProperty("amount", 0); }
      set { this["amount"] = value.ToString(); }
    }

  }
}
