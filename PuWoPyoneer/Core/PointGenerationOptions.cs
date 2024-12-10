
using System;
using Autodesk.Revit.DB;

namespace PuWoGenerator.Core
{
    public class PointGenerationOptions
    {
        public int PointsPerFace { get; set; } = 100;
        public double NoiseLevel { get; set; } = 0.1;
        public bool UseNoiseVolume { get; set; } = true;
        public Func<Random, XYZ> CustomNoiseStrategy { get; set; }
        public Func<GeometryObject, bool> GetConnectedFaces { get; private set; }

        public PointGenerationOptions(Func<GeometryObject, bool> getConnectedFaces)
        {
            GetConnectedFaces = getConnectedFaces;
        }
    }
}
