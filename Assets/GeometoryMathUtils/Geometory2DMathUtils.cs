using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometoryMathUtils
{
    // Analytical geometory formula
    public class Circumcenter
    {
        public float radius;
        public Vector2 center;
    }

    public class Geometory2DMathUtils
    {
        // kind of lerp. If ratio sets 1.0f. It will output mid point.
        public static Vector2 GetDividingPoint(Vector2 p0, Vector2 p1, float ratio)
        {
            float x = (p0.x + (ratio * p1.x)) / (1f + ratio);
            float y = (p0.y + (ratio * p1.y)) / (1f + ratio);
            return new Vector2(x, y);
        }

        public static Vector2 GetMidPoint(Vector2 p0, Vector2 p1)
        {
            float x = (p0.x + p1.x) / 2f;
            float y = (p0.y + p1.y) / 2f;
            return new Vector2(x, y);
        }

        public static Vector2 GetCentroidPointOfATriangle(Vector2 p0, Vector2 p1, Vector2 p2)
        {
            float x = (p0.x + p1.x + p2.x) / 3f;
            float y = (p0.y + p1.y + p2.y) / 3f;
            return new Vector2(x, y);
        }

        public static Vector2 GetIncenterPointOfATriangle(Vector2 p0, Vector2 p1, Vector2 p2)
        {
            float a = GetDistance(p1, p2);
            float b = GetDistance(p2, p0);
            float c = GetDistance(p0, p1);

            float x = ((a * p0.x) + (b * p1.x) + (c * p2.x)) / (a + b + c);
            float y = ((a * p0.y) + (b * p1.y) + (c * p2.y)) / (a + b + c);

            return new Vector2(x, y);
        }

        // using Heron's formula to calculate area of triangle
        public static float GetAreaOfATriangle(Vector2 p0, Vector2 p1, Vector2 p2)
        {
            float a = GetDistance(p0, p1);
            float b = GetDistance(p1, p2);
            float c = GetDistance(p2, p0);

            float s = (a + b + c) / 2;

            float area = Mathf.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        // Circumcenter formula. this one is a kind of the bounding sphere.
        public static Circumcenter GetCircumcenter(Vector2 p0, Vector2 p1, Vector2 p2)
        {
            float a1 = -((p1.x - p0.x) / (p1.y - p0.y));
            float b1 = ((p1.y + p0.y) / 2f) - (a1 * ((p1.x + p0.x) / 2f));
            float a2 = -((p2.x - p1.x) / (p2.y - p1.y));
            float b2 = ((p2.y + p1.y) / 2f) - (a2 * ((p2.x + p1.x) / 2f));

            float cx = (b2 - b1) / (a1 - a2);
            float cy = a1 * cx + b1;

            float r = Mathf.Sqrt(Mathf.Pow(p0.x - cx, 2) + Mathf.Pow(p0.y - cy, 2));

            Circumcenter ccenter = new Circumcenter();
            ccenter.center = new Vector2(cx, cy);
            ccenter.radius = r;

            return ccenter;
        }

        public static float GetDistance(Vector2 p0, Vector2 p1)
        {
            return Mathf.Sqrt(Mathf.Pow(p1.x - p0.x, 2) + Mathf.Pow(p1.y - p0.y, 2));
        }
    }
}
