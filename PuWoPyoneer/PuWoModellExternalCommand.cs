using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace PuWoGenerator
{
  public class PuWoModellExternalCommand : IExternalCommand
  {
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
      Document document = commandData.Application.ActiveUIDocument.Document;

      return Result.Succeeded;
    }
  }
}
