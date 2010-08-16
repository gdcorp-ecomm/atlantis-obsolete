namespace Atlantis.Framework.OutreachCalculateDowngrade.Interface
{
  public class RequiredMailingPackInfo
  {
    public int MailingPackSize { get; private set; }
    public long PF_ID { get; private set; }
    public int Quantity { get; private set; }

    public RequiredMailingPackInfo(int mailingPackSize,
                                   long pf_id,
                                   int quantity)
    {
      MailingPackSize = mailingPackSize;
      PF_ID = pf_id;
      Quantity = quantity;
    }
  }
}
