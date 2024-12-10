using System;
using System.Collections.Generic;
using System.IO;

namespace PuWoGenerator.Core
{
    public class PlyFile
    {
        public List<MetaPoint> Vertices { get; set; } = new List<MetaPoint>();

        public void Save(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                // Header schreiben
                writer.WriteLine("ply");
                writer.WriteLine("format ascii 1.0");
                writer.WriteLine($"element vertex {Vertices.Count}");
                writer.WriteLine("property float x");
                writer.WriteLine("property float y");
                writer.WriteLine("property float z");
                writer.WriteLine("property string material_name");
                writer.WriteLine("property int face_id");
                writer.WriteLine("end_header");

                // Punkte mit Metadaten schreiben
                foreach (var vertex in Vertices)
                {
                    writer.WriteLine($"{vertex.XAxis} {vertex.YAxis} {vertex.ZAxis} {vertex.Label} {vertex.SegmentId}");
                }
            }

            Console.WriteLine($"PLY-Datei erfolgreich gespeichert unter: {filePath}");
        }
    }
}
