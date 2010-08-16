using System;
using System.Text;
using System.Xml;
using System.IO;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OutreachResellerOptout.Interface
{
  public class OutreachResellerOptoutRequestData : RequestData
  {
    public TimeSpan RequestTimeout { get; set; }
    public string Email { get; private set; }
    public int PrivateLabelId { get; private set; }

    public OutreachResellerOptoutRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      string email, int privateLabelId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(4);
      Email = email;
      PrivateLabelId = privateLabelId;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("OutreachResellerOptout is not a cacheable request.");
    }

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));

      xtwRequest.WriteStartElement("subscriber");
      xtwRequest.WriteStartElement("reseller_private_label_id");
      xtwRequest.WriteValue(PrivateLabelId);
      xtwRequest.WriteEndElement();
      xtwRequest.WriteStartElement("email");
      xtwRequest.WriteValue(Email);
      xtwRequest.WriteEndElement();
      xtwRequest.WriteEndElement(); //subscriber
      return sbRequest.ToString();
    }

  }
}
