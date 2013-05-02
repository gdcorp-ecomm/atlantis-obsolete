using System.Text;
using System.Text.RegularExpressions;
using Atlantis.Framework.Conditions.Interface;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Render.ExpressionParser;
using Atlantis.Framework.Render.MarkupParser;
using Atlantis.Framework.Render.Pipeline.Interface;

namespace Atlantis.Framework.Providers.CDS
{
  internal class CDSWidgetConditionRenderHandler : IRenderHandler
  {
    private const string PRE_PROCESSOR_PREFIX = "##";
    private const string CARRAIGE_RETURN_ENCODED = "\\r\\n";
    private const string CARRAIGE_RETURN_DECODED = "\r\n";

    private static readonly Regex _widgetContentRegex = new Regex(@"""\s*:\s*""(?<content>[^""\\]*(?:\\.[^""\\]*)*)""", RegexOptions.Compiled);

    public void ProcessContent(IProcessedRenderContent processRenderContent, IProviderContainer providerContainer)
    {
      ExpressionParserManager expressionParserManager = new ExpressionParserManager(providerContainer);
      expressionParserManager.EvaluateExpressionHandler += ConditionHandlerManager.EvaluateCondition;

      StringBuilder finalContentBuilder = new StringBuilder(processRenderContent.Content);

      MatchCollection widgetContentMatches = _widgetContentRegex.Matches(processRenderContent.Content);

      foreach (Match widgetContentMatch in widgetContentMatches)
      {
        string widgetContent = widgetContentMatch.Groups["content"].Value;

        string modifiedContent = MarkupParserManager.ParseAndEvaluate(widgetContent.Replace(CARRAIGE_RETURN_ENCODED, CARRAIGE_RETURN_DECODED), 
                                                                      PRE_PROCESSOR_PREFIX, 
                                                                      expressionParserManager.EvaluateExpression);

        finalContentBuilder.Replace(widgetContent, modifiedContent.Replace(CARRAIGE_RETURN_DECODED, CARRAIGE_RETURN_ENCODED));
      }

      processRenderContent.OverWriteContent(finalContentBuilder.ToString());
    }
  }
}