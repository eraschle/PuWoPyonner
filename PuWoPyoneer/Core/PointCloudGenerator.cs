

using System.Collections.Generic;
using Autodesk.Revit.DB;
using PuWoGenerator.Core;
using PuWoGenerator.Factories;

namespace PointCloudGenerator.Core
{
    public class PointCloudGenerator
    {
        public IEnumerable<XYZ> GeneratePointsForElement(Element element, PointGenerationOptions options)
        {
            var points = new List<XYZ>();
            var geometryElement = element.get_Geometry(
                new Options { ComputeReferences = true }
            );

            foreach (GeometryObject geometry in geometryElement)
            {
                var handler = GeometryHandlerFactory.GetHandler(geometry);
                points.AddRange(handler.GeneratePoints(geometry, options));
            }

            return points;
        }
    }
}
