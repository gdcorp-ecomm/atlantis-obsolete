using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.PurchaseBasket.Interface
{
  public class PaymentUseZero : PaymentElement
  {
    public override string ElementName
    {
      get { return "ZeroPayment"; }
    }
  }
}
