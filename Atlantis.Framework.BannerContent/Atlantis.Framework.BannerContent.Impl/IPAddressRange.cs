using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace Atlantis.Framework.BannerContent.Impl
{
  class IPAddressRange
  {
    // **************************************************************** //

    const string sIPAddressPattern
      = @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

    // **************************************************************** //

    Int32 m_i32IPAddress;
    Int32 m_i32Mask;

    // **************************************************************** //

    IPAddressRange(Int32 i32IPAddress, Int32 i32Mask)
    {
      m_i32IPAddress = i32IPAddress & i32Mask;
      m_i32Mask = i32Mask;
    }

    // **************************************************************** //

    /*
     * Valid IP Address Range Format:
     * 
     * - "*": All valid IP addresses
     * - "aaa.*": All valid IP addresses matching the first part "aaa"
     * - "aaa.bbb.*": All valid IP addresses matching the first and second part, "aaa" and "bbb"
     * - "aaa.bbb.ccc.*": All valid IP addresses matching the first, second, and thrird part, 
     *                    "aaa", "bbb", and "ccc"
     * - "aaa.bbb.ccc.ddd": All valid IP Address matching the address exactly
     * - "aaa.bbb.ccc.ddd/n": CIDR notation - A range of IP addresses matching the first n bits of
     *                        "aaa.bbb.ccc.ddd"
     *
     * */

    public static bool TryParse(string sIPAddressValue, out IPAddressRange range)
    {
      bool bResult = false;
      IPAddressRange result = null;
      Int32 i32IPAddress = 0;
      int iBits = 32;

      string[] sBytes = sIPAddressValue.Split('.');

      try
      {
        if (sBytes.Length == 4 && sBytes[3].IndexOf('/') > -1)
        {
          string[] sRanges = sBytes[3].Split('/');
          sBytes[3] = sRanges[0];

          if (sRanges.Length == 2)
          {
            iBits = Convert.ToInt32(sRanges[1]);

            if (iBits >= 0 && iBits <= 32)
            {
              for (int index = 0; index < sBytes.Length; ++index)
                i32IPAddress += Convert.ToByte(sBytes[index]) << (8 * index);

              result = new IPAddressRange(i32IPAddress, (1 << iBits) - 1);
              bResult = true;
            }
          }
        }
        else if (sBytes.Length > 0 && sBytes.Length <= 4)
        {
          bool bDone = false;
          for (int index = 0; index < sBytes.Length && !bDone; ++index)
          {
            if (sBytes[index] == "*")
            {
              bDone = true;
              iBits = 8 * index;
            }
            else
              i32IPAddress += Convert.ToByte(sBytes[index]) << (8 * index);
          }

          result = new IPAddressRange(i32IPAddress, (1 << iBits) - 1);
          bResult = true;
        }
      }
      catch
      {
        bResult = false;
        result = null;
      }

      range = result;
      return bResult;
    }

    // **************************************************************** //

    public bool WithinRange(string sIPAddress)
    {
      bool bResult = false;
      Int32 i32IPAddress = 0;

      if (Regex.IsMatch(sIPAddress, sIPAddressPattern))
      {
        string[] sBytes = sIPAddress.Split('.');

        for (int index = 0; index < 4; ++index)
          i32IPAddress += Convert.ToByte(sBytes[index]) << (8 * index);

        if ((m_i32Mask & i32IPAddress) == m_i32IPAddress)
          bResult = true;
      }

      return bResult;
    }

    // **************************************************************** //
  }
}
