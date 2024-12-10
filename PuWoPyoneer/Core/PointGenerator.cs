
using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace PointCloudGenerator.Core
{
    public class PointGenerator
    {
        public static IEnumerable<XYZ> GeneratePointsOnFace(Face face, int numberOfPoints, Func<Random, XYZ> noiseGenerator = null)
        {
            var points = new List<XYZ>();
            var bbox = face.GetBoundingBox();
            double uMin = bbox.Min.U;
            double vMin = bbox.Min.V;
            double uMax = bbox.Max.U;
            double vMax = bbox.Max.V;

            Random random = new Random();

            for (int i = 0; i < numberOfPoints; i++)
            {
                double u = uMin + random.NextDouble() * (uMax - uMin);
                double v = vMin + random.NextDouble() * (vMax - vMin);
                XYZ point = face.Evaluate(new UV(u, v));

                if (noiseGenerator != null)
                {
                    point += noiseGenerator(random);
                }

                points.Add(point);
            }

            return points;
        }

        public static XYZ GenerateDefaultNoise(Random random, double noiseLevel)
        {
            double dx = (random.NextDouble() - 0.5) * 2 * noiseLevel;
            double dy = (random.NextDouble() - 0.5) * 2 * noiseLevel;
            double dz = (random.NextDouble() - 0.5) * 2 * noiseLevel;
            return new XYZ(dx, dy, dz);
        }
    }
}
