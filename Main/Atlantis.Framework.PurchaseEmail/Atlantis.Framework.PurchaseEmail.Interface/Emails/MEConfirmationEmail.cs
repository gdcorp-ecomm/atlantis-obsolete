﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Providers.ProviderContainer.Impl;

namespace Atlantis.Framework.PurchaseEmail.Interface.Emails
{
  internal class MEConfirmationEmail : PurchaseConfirmationEmailBase
  {
    public MEConfirmationEmail(OrderData orderData, EmailRequired emailRequired, ObjectProviderContainer objectContainer)
      : base(orderData, emailRequired,objectContainer)
    {
    }

    protected override void SetParams()
    {
      SetParam(EmailTokenNames.ShopperId, ShopperContext.ShopperId);
      SetParam(EmailTokenNames.OrderTime, OrderTime);
      SetParam(EmailTokenNames.OrderId, Order.OrderId);
      SetParam(EmailTokenNames.ItemsText, GetItemsText());
    }

    protected override EmailTemplate EmailTemplate
    {
      get { return EmailTemplates[EmailTemplateType.MEPurchaseReceipt]; }
    }
  }
}
