using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace Atlantis.Framework.ContextWrapper
{
  public static class HttpContextWrapper
  {

/* THIS SHOULD ONLY BE USED IN DEBUG
 * Put your code that references the Mock features in a #if DEBUG block 
 */
#if DEBUG

    private static bool _useMockContext = false;
    private static string _mockRequestPage = "null.html";
    private static string _mockRequestUrl = "http://localhost/null/null.html";
    private static string _mockRequestQueryString = "?mock=true";

    [ThreadStatic]
    private static System.Web.HttpContext _mockContext;

    /// <summary>
    /// This property can only be used in DEBUG.  Put your code that uses it in a #if DEBUG block.
    /// It is only designed for unit tests
    /// </summary>
    public static bool UseMockContext
    {
      get { return _useMockContext; }
      set { _useMockContext = value; }
    }

    /// <summary>
    /// This property can only be used in DEBUG.  Put your code that uses it in a #if DEBUG block.
    /// It is only designed for unit tests
    /// </summary>
    public static string MockRequestPage
    {
      get { return _mockRequestPage; }
      set
      {
        _mockRequestPage = value;
        ResetMockContext();
      }
    }

    /// <summary>
    /// This property can only be used in DEBUG.  Put your code that uses it in a #if DEBUG block.
    /// It is only designed for unit tests
    /// </summary>
    public static string MockRequestUrl
    {
      get { return _mockRequestUrl; }
      set
      {
        _mockRequestUrl = value;
        ResetMockContext();
      }
    }

    /// <summary>
    /// This property can only be used in DEBUG.  Put your code that uses it in a #if DEBUG block.
    /// It is only designed for unit tests
    /// </summary>
    public static string MockRequestQueryString
    {
      get { return _mockRequestQueryString; }
      set
      {
        _mockRequestQueryString = value;
        ResetMockContext();
      }
    }

    /// <summary>
    /// This method can only be used in DEBUG.  Put your code that uses it in a #if DEBUG block.
    /// It is only designed for unit tests
    /// </summary>
    public static void ResetMockContext()
    {
      _mockContext = null;
    }

#endif // DEBUG

    public static System.Web.HttpContext Current
    {
      get
      {
        System.Web.HttpContext result = System.Web.HttpContext.Current;

#if DEBUG
        if (_useMockContext)
        {
          if (_mockContext == null)
          {
            StringWriter writer = new StringWriter();
            HttpRequest request = new HttpRequest(_mockRequestPage, _mockRequestUrl, _mockRequestQueryString);
            HttpResponse response = new HttpResponse(writer);
            _mockContext = new System.Web.HttpContext(request, response);

            ConstructorInfo[] consInfo = typeof(HttpSessionState).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            object[] args = new object[1];
            args[0] = new MockSession();
            object oSession = consInfo[0].Invoke(args);
            HttpSessionState session = (HttpSessionState)oSession;
            _mockContext.Items["AspSession"] = session;
          }

          result = _mockContext;
        }
#endif // DEBUG

        return result;
      }
    }
  }
}
