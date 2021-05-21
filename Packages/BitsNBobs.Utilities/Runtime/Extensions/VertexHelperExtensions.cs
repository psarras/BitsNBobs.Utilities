using System;
using UnityEngine;
using UnityEngine.UI;

namespace BitsNBobs.Extensions
{
    public static class VertexHelperExtensions
    {
        /// <summary>
        ///  4 ------- 3
        ///  |         |
        ///  |         |
        ///  1 ------- 2
        /// 
        /// </summary>
        /// <param name="vh"></param>
        /// <param name="center"></param>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        /// <param name="color"></param>
        public static void AddRect(this VertexHelper vh, Vector3 center, float xSize, float ySize, Color color)
        {
            var vert = UIVertex.simpleVert;
            var right = new Vector3(xSize / 2, 0, 0);
            var bottom = new Vector3(0, ySize / 2, 0);
            vert.color = color;

            var topLeft = center - right - bottom;
            vert.position = topLeft;
            vh.AddVert(vert);
            var topRight = center + right - bottom;
            vert.position = topRight;
            vh.AddVert(vert);
            var botRight = center + right + bottom;
            vert.position = botRight;
            vh.AddVert(vert);
            var botLeft = center - right + bottom;
            vert.position = botLeft;
            vh.AddVert(vert);

            vh.AddTriangle(vh.currentVertCount - 4, vh.currentVertCount - 2, vh.currentVertCount - 3);
            vh.AddTriangle(vh.currentVertCount - 4, vh.currentVertCount - 1, vh.currentVertCount - 2);
        }


        /// <summary>
        /// 
        ///  8 ------------- 7
        ///  |  4 ------- 3  |
        ///  |  |         |  |
        ///  |  |         |  |
        ///  |  1 ------- 2  |
        ///  5 ------------- 6
        /// 
        /// </summary>
        /// <param name="vh"></param>
        /// <param name="center"></param>
        /// <param name="xSize"></param>
        /// <param name="ySize"></param>
        /// <param name="thickness"></param>
        /// <param name="color"></param>
        public static void AddRectOutline(this VertexHelper vh, Vector3 center,
            float xSize, float ySize, float thickness, Color color)
        {
            var vert = UIVertex.simpleVert;
            var right = new Vector3(xSize / 2, 0, 0);
            var bottom = new Vector3(0, ySize / 2, 0);
            vert.color = color;

            var topLeft = center - right - bottom;
            vert.position = topLeft;
            vh.AddVert(vert);
            var topRight = center + right - bottom;
            vert.position = topRight;
            vh.AddVert(vert);
            var botRight = center + right + bottom;
            vert.position = botRight;
            vh.AddVert(vert);
            var botLeft = center - right + bottom;
            vert.position = botLeft;
            vh.AddVert(vert);

            var innerRight = new Vector3(thickness, 0, 0);
            var innerUp = new Vector3(0, thickness, 0);

            var topLeftInner = topLeft + innerRight + innerUp;
            vert.position = topLeftInner;
            vh.AddVert(vert);
            var topRightInner = topRight - innerRight + innerUp;
            vert.position = topRightInner;
            vh.AddVert(vert);
            var botRightInner = botRight - innerRight - innerUp;
            vert.position = botRightInner;
            vh.AddVert(vert);
            var botLeftInner = botLeft + innerRight - innerUp;
            vert.position = botLeftInner;
            vh.AddVert(vert);

            vh.AddTriangle(vh.currentVertCount - 8, vh.currentVertCount - 3,
                vh.currentVertCount - 7);
            vh.AddTriangle(vh.currentVertCount - 8, vh.currentVertCount - 4,
                vh.currentVertCount - 3);

            vh.AddTriangle(vh.currentVertCount - 7, vh.currentVertCount - 2,
                vh.currentVertCount - 6);
            vh.AddTriangle(vh.currentVertCount - 7, vh.currentVertCount - 3,
                vh.currentVertCount - 2);

            vh.AddTriangle(vh.currentVertCount - 6, vh.currentVertCount - 1,
                vh.currentVertCount - 2);
            vh.AddTriangle(vh.currentVertCount - 6, vh.currentVertCount - 1,
                vh.currentVertCount - 5);

            vh.AddTriangle(vh.currentVertCount - 5, vh.currentVertCount - 4,
                vh.currentVertCount - 8);
            vh.AddTriangle(vh.currentVertCount - 5, vh.currentVertCount - 1,
                vh.currentVertCount - 4);
        }

        public static void AddPolyline(this VertexHelper vh, Vector3[] positions, float thickness, Color color)
        {
            var vert = UIVertex.simpleVert;
            vert.color = color;
            var startVertex = vh.currentVertCount;

            var dir = positions[1] - positions[0];
            var prevDir = new Vector3(dir.x, dir.y, dir.z);
            var halfThickness = thickness / 2;

            for (var i = 0; i < positions.Length; i++)
            {
                // Store the outgoing edge
                if (i + 1 < positions.Length)
                {
                    dir = positions[i + 1] - positions[i];
                }

                // Get the Average
                var average = dir.normalized + prevDir.normalized;
                average = average.normalized;
                //Debug.DrawRay(positions[i], average * halfThickness, Color.magenta);
                
                var diag = Vector3.Cross(average, Vector3.back);
                diag = diag.normalized;
                
                var perp = Vector3.Cross(dir, Vector3.back);
                perp = perp.normalized;
                //Debug.DrawRay(positions[i], perp * halfThickness, Color.blue);
                var perp2 = Vector3.Cross(prevDir, Vector3.back);
                perp2 = perp2.normalized;
                //Debug.DrawRay(positions[i], perp2 * halfThickness, Color.cyan);
                
                //if (i < positions.Length - 1)
                //    Debug.DrawLine(positions[i], positions[i + 1], Color.yellow);

                var f = Vector3.Angle(diag, perp2);

                var angle = Mathf.Deg2Rad * (f);
                var dist = halfThickness / Mathf.Cos(angle);

                //Debug.DrawRay(positions[i], diag * (dist), Color.red);
                // Add two Vertices
                var pos1 = positions[i] + diag * (dist);
                vert.position = pos1;
                vh.AddVert(vert);
                var pos2 = positions[i] - diag * (dist);
                vert.position = pos2;
                vh.AddVert(vert);

                // Store the previous
                prevDir = new Vector3(dir.x, dir.y, dir.z);
            }

            // Example of a section of vertices
            // i     --------- i + 2 ------------ i + 4
            // i + 1 --------- i + 3 ------------ i + 5

            // We expect and even number of vertices
            for (int i = startVertex; i < vh.currentVertCount - 3; i += 2)
            {
                vh.AddTriangle(i, i + 3, i + 2);
                vh.AddTriangle(i, i + 1, i + 3);
            }
        }

        public static float GetNormalizedSliderPosition(this Slider slider)
        {
            var normal = (slider.value - slider.minValue) / (slider.maxValue - slider.minValue);
            return normal * slider.GetComponent<RectTransform>().sizeDelta.x;
        }
    }
}