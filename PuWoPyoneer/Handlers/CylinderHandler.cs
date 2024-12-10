
using System.Collections.Generic;
using Autodesk.Revit.DB;
using PointCloudGenerator.Core;
using System;
using System.Linq;
using PuWoGenerator.Core;

namespace PuWoGenerator.Handlers
{
    public class CylinderHandler : IGeometryHandler
    {
        public bool HasTwoCurves(GeometryInstance geometry)
        {
            var curves = geometry.GetInstanceGeometry().OfType<Solid>().ToList();
            return curves.Count() == 2;
        }

        public bool HasTwoFaces(GeometryInstance geometry)
        {
            var faces = geometry.GetInstanceGeometry().OfType<Face>().ToList();
            return faces.Count() == 2;
        }

        private bool IsCylindricalFace(Face face)
        {
            return face.GetSurface() is Cylinder;
        }

        public bool IsApplicable(GeometryInstance geometry)
        {
            return HasTwoCurves(geometry) && HasTwoFaces(geometry);
        }

        public IEnumerable<XYZ> GeneratePoints(GeometryInstance geometry, PointGenerationOptions options)
        {
            if (!IsApplicable(geometry))
                throw new ArgumentException("Invalid geometry type for CylinderHandler, got {typeOf(geometry.GetType()})");

            return PointGenerator.GeneratePointsOnFace(
                geometry.GetInstanceGeometry(),
                options.PointsPerFace,
                random => PointGenerator.GenerateDefaultNoise(random, options.NoiseLevel)
            );
        }

        public IEnumerable<GeometryObject> Connected_Geometries(GeometryInstance geometry)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GeometryAdapter> BorderGeometries()
        {
            throw new NotImplementedException();
        }
    }
}
