using UnityEngine;

namespace BitsNBobs.Extensions
{
    public static class MeshExtension
    {
        public static Mesh Clone(this Mesh mesh)
        {
            var m = new Mesh();
            m.vertices = mesh.vertices;
            m.triangles = mesh.triangles;
            m.colors = mesh.colors;
            m.normals = mesh.normals;
            m.RecalculateBounds();
            m.RecalculateTangents();
            return m;
        }
        
    }
}