using BitsNBobs.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(CanvasRenderer))][ExecuteInEditMode]
    public class PolylineUi : Graphic
    {
        [SerializeField] private Vector3[] points;
        [SerializeField] private float thickness;

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            vh.AddPolyline(points, thickness, color);
        }
    }
}