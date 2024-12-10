
using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using PointCloudGenerator.Core;

namespace PuWoGenerator.Factories
{
    public static class GeometryHandlerFactory
    {
        private static List<IGeometryHandler> _handlers;
        public static void SetGeometryHandler(List<IGeometryHandler> handlers)
        {
            _handlers = handlers;
        }

        public static IGeometryHandler GetHandler(GeometryInstance geometry)
        {
            foreach (var handler in _handlers)
            {
                if (handler.IsApplicable(geometry))
                {
                    return handler;
                }
            }
            throw new NotSupportedException($"Unsupported geometry type: {geometry.GetType()}");
        }
    }
}
