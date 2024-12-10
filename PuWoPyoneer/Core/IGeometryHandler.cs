using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using PuWoGenerator.Core;

namespace PointCloudGenerator.Core
{
    public interface IGeometryHandler
    {
        bool IsApplicable(GeometryInstance geometry);
        IEnumerable<XYZ> GeneratePoints(GeometryInstance geometry, PointGenerationOptions options);
        IEnumerable<GeometryObject> Connected_Geometries(GeometryInstance geometry);
        IEnumerable<GeometryAdapter> BorderGeometries();
    }

    public class GeometryAdapter
    {
        public GeometryInstance Geometry { get; }
        public GeometryAdapter(GeometryInstance geometry)
        {
            Geometry = geometry;
        }
        public IEnumerable<GeometryObject> GetBorder()
        {
            return Geometry.GetInstanceGeometry().OfType<GeometryElement>();
        }
    }

    public class GeometryManager
    {
        private readonly IList<GeometryAdapter> _geometryAdapters = new List<GeometryAdapter>();

        public void RegisterGeometryAdapter(GeometryAdapter adapter)
        {
            _geometryAdapters.Add(adapter);
        }

        public IEnumerable<GeometryObject> Connected_Geometry(GeometryInstance geometry, PointGenerationOptions options)
        {
            return _geometryAdapters
                .Where(adapter => adapter.Geometry == geometry)
                .SelectMany(adapter => adapter.GetBorder())
                .Where(options.GetConnectedFaces);
        }

    }

}
