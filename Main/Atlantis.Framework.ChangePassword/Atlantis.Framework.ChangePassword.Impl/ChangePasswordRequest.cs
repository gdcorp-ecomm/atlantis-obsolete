using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;
using Atlantis.Framework.ChangePassword.Interface;
using Atlantis.Framework.ChangePassword.Impl.AuthenticationWS;
using System.Text.RegularExpressions;

namespace Atlantis.Framework.ChangePassword.Impl
{
  public class ChangePasswordRequest : IRequest
  {
    private HashSet<int> ValidateRequest(ChangePasswordRequestData request, WScgdAuthenticateService service)
    {
      HashSet<int> result = new HashSet<int>();

      #region CurrentPassword

      if (string.IsNullOrEmpty(request.CurrentPassword))
      {
        result.Add(ChangePasswordStatusCodes.CurrentPasswordRequired);
      }
      else if (request.CurrentPassword.Length < 5)
      {
        result.Add(ChangePasswordStatusCodes.CurrentPasswordToShort);
      }

      #endregion

      #region NewPassword

      if (string.IsNullOrEmpty(request.NewPassword))
      {
        result.Add(ChangePasswordStatusCodes.PasswordRequired);
      }
      else
      {
        if (request.NewPassword.Length > 25)
        {
          result.Add(ChangePasswordStatusCodes.PasswordToLong);
        }
        else if (request.NewPassword.Length < 5)
        {
          result.Add(ChangePasswordStatusCodes.PasswordToShort);
        }

        if (Regex.Match(request.NewPassword, "[^\x20-\x7E]").Success)
        {
          result.Add(ChangePasswordStatusCodes.PasswordInvalidCharacters);
        }
        else if (request.UseStrongPassword)
        {
          // Validate password strength
          int strengthResult = service.IsStrongPassword(request.ShopperID, request.NewPassword);
          if (strengthResult != ChangePasswordStatusCodes.Success)
          {
            result.Add(strengthResult);
          }
        }
      }

      #endregion

      #region Login

      if (string.IsNullOrEmpty(request.NewLogin))
      {
        result.Add(ChangePasswordStatusCodes.LoginRequired);
      }
      else 
      {
        if (request.NewLogin.Length > 30)
        {
          result.Add(ChangePasswordStatusCodes.LoginMaxLength);
        }

        if (Regex.Match(request.NewLogin, @"[^\-A-Za-z0-9]").Success)
        {
          result.Add(ChangePasswordStatusCodes.LoginInvalidCharacters);
        }
      }

      #endregion

      #region Hint

      if (string.IsNullOrEmpty(request.NewHint))
      {
        result.Add(ChangePasswordStatusCodes.HintRequired);
      }
      else
      {
        if (request.NewHint.Length > 255)
        {
          result.Add(ChangePasswordStatusCodes.HintMaxLength);
        }

        if (Regex.Match(request.NewHint, "[^\x20-\x3b\x3f-\x7e]").Success)
        {
          result.Add(ChangePasswordStatusCodes.HintInvalidCharacters);
        }
      }

      #endregion

      #region Cross-Field Rules

      if (request.NewLogin == request.NewPassword)
      {
        result.Add(ChangePasswordStatusCodes.LoginPasswordMatch);
      }

      if (request.NewLogin == request.NewHint)
      {
        result.Add(ChangePasswordStatusCodes.LoginHintMatch);
      }

      if (request.NewHint == request.NewPassword)
      {
        result.Add(ChangePasswordStatusCodes.PasswordHintMatch);
      }

      #endregion

      return result;
    }

    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      ChangePasswordResponseData responseData = null;
      string responseXml = string.Empty;

      try
      {
        string authServiceUrl = ((WsConfigElement)oConfig).WSURL;
        if (!authServiceUrl.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
        {
          throw new AtlantisException(oRequestData, "ChangePassword.RequestHandler", "ChangePassword WS URL in atlantis.config must use https.", string.Empty);
        }

        ChangePasswordRequestData request = (ChangePasswordRequestData)oRequestData;
        WScgdAuthenticateService authenticationService = new WScgdAuthenticateService();
        authenticationService.Url = authServiceUrl;

        string errorOutput = null;

        HashSet<int> responseCodes = ValidateRequest(request, authenticationService);
        if (responseCodes.Count > 0)
        {
          errorOutput = "Request not valid.";
        }
        else
        {
          int useStrongPasswordValue = 0;
          if (request.UseStrongPassword)
          {
            useStrongPasswordValue = 1;
          }

          int resultCode = ChangePasswordStatusCodes.Failure;
          resultCode = authenticationService.ChangePassword(
            request.ShopperID, request.PrivateLabelId, request.CurrentPassword, request.NewPassword,
            request.NewHint, request.NewLogin, useStrongPasswordValue, out errorOutput);

          responseCodes.Add(resultCode);
        }
        
        responseData = new ChangePasswordResponseData(responseCodes, errorOutput);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new ChangePasswordResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new ChangePasswordResponseData(oRequestData, ex);
      }

      return responseData;
    }

    #endregion
  }
}
