using System;
using System.Data.SqlClient;

namespace Atlantis.Framework.MyaResourceReverseQty.Interface
{
  public class ResourceReverseQty
  {
    public string OrderId { get; set; }
    public int RowId { get; set; }
    public int CanBeReversedQuantity { get; set; }

    public ResourceReverseQty()
    { 
    }

    public ResourceReverseQty(SqlDataReader reader)
    {
      OrderId = reader["order_id"] == DBNull.Value ? string.Empty : Convert.ToString(reader["order_id"]);
      RowId = reader["order_id"] == DBNull.Value ? -1 : Convert.ToInt32(reader["row_id"]);
      CanBeReversedQuantity = reader["order_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["canBeReversed"]);
    }
  }
}
