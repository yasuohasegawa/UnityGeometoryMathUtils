using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometoryMathUtils
{
    public class Geometory3DMathUtils
    {
        // kind of lerp. If ratio sets 1.0f. It will output mid point.
        public static Vector3 GetDividingPoint(Vector3 p0, Vector3 p1, float ratio)
        {
            float x = (p0.x + (ratio * p1.x)) / (1f + ratio);
            float y = (p0.y + (ratio * p1.y)) / (1f + ratio);
            float z = (p0.z + (ratio * p1.z)) / (1f + ratio);
            return new Vector3(x, y, z);
        }

        public static Vector3 GetMidPoint(Vector3 p0, Vector3 p1)
        {
            float x = (p0.x + p1.x) / 2f;
            float y = (p0.y + p1.y) / 2f;
            float z = (p0.z + p1.z) / 2f;
            return new Vector3(x, y, z);
        }

        public static Vector3 GetCentroidPointOfATriangle(Vector3 p0, Vector3 p1, Vector3 p2)
        {
            float x = (p0.x + p1.x + p2.x) / 3f;
            float y = (p0.y + p1.y + p2.y) / 3f;
            float z = (p0.z + p1.z + p2.z) / 3f;
            return new Vector3(x, y, z);
        }

        public static Vector3 GetIncenterPointOfATriangle(Vector3 p0, Vector3 p1, Vector3 p2)
        {
            float a = GetDistance(p1, p2);
            float b = GetDistance(p2, p0);
            float c = GetDistance(p0, p1);

            float x = ((a * p0.x) + (b * p1.x) + (c * p2.x)) / (a + b + c);
            float y = ((a * p0.y) + (b * p1.y) + (c * p2.y)) / (a + b + c);
            float z = ((a * p0.z) + (b * p1.z) + (c * p2.z)) / (a + b + c);

            return new Vector3(x, y, z);
        }

        // using Heron's formula to calculate area of triangle
        public static float GetAreaOfATriangle(Vector3 p0, Vector3 p1, Vector3 p2)
        {
            float a = GetDistance(p0, p1);
            float b = GetDistance(p1, p2);
            float c = GetDistance(p2, p0);

            float s = (a + b + c) / 2;

            float area = Mathf.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static float GetDistance(Vector3 p0, Vector3 p1)
        {
            return Mathf.Sqrt(Mathf.Pow(p1.x - p0.x, 2) + Mathf.Pow(p1.y - p0.y, 2) + Mathf.Pow(p1.z - p0.z, 2));
        }
    }
}
