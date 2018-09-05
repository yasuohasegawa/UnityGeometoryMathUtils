using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeometoryMathUtils
{
    public enum SortType
    {
        ACD,
        DEC
    }

    public class GeometoryMath
    {
        public static Vector3 GetFurthestPointFromCenter(Vector3 center, Vector3 p0, Vector3 p1, Vector3 p2)
        {
            return Sort(center, p0, p1, p2, SortType.DEC);
        }

        public static Vector3 GetClosestPointFromCenter(Vector3 center, Vector3 p0, Vector3 p1, Vector3 p2)
        {
            return Sort(center, p0, p1, p2, SortType.ACD);
        }

        private static Vector3 Sort(Vector3 center, Vector3 p0, Vector3 p1, Vector3 p2, SortType type)
        {
            float a = Geometory3DMathUtils.GetDistance(p0, center);
            float b = Geometory3DMathUtils.GetDistance(p1, center);
            float c = Geometory3DMathUtils.GetDistance(p2, center);
            float[] points = { a, b, c };
            Vector3 res = Vector3.zero;

            float temp = 0f;
            for (int i = 0; i < points.Length; i++)
            {

                for (int j = 1; j < points.Length; j++)
                {
                    if (type == SortType.DEC)
                    {
                        if (points[j - 1] < points[j])
                        {
                            temp = points[j];
                            points[j] = points[j - 1];
                            points[j - 1] = temp;
                        }
                    } else {
                        if (points[j - 1] > points[j])
                        {
                            temp = points[j];
                            points[j] = points[j - 1];
                            points[j - 1] = temp;
                        }
                    }
                }
                
            }

            if(a == points[0])
            {
                res = p0;
            } else if(b == points[0]) {
                res = p1;
            } else if(c == points[0]) {
                res = p2;
            }

            /* // check value
            Debug.Log(">>>>>>>>>");
            for(int i = 0; i< points.Length; i++)
            {
                Debug.Log(points[i]);
            }
            */

            return res;
        }

    }
}