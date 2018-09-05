using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeometoryMathUtils;

public class TestMathUtils : MonoBehaviour {

    public GameObject p0;
    public GameObject p1;
    public GameObject p2;

    public GameObject p3;

    private Circumcenter ccenter;

    // Use this for initialization
    void Start () {
        /*
        // 3d test code
        Vector3 p = Geometory3DMathUtils.GetDividingPoint(p0.transform.position, p1.transform.position, 100.0f);
        //p = Geometory3DMathUtils.GetMidPoint(p0.transform.position, p1.transform.position);
        p = Geometory3DMathUtils.GetCentroidPointOfATriangle(p0.transform.position, p1.transform.position, p2.transform.position);
        //p = Geometory3DMathUtils.GetIncenterPointOfATriangle(p0.transform.position, p1.transform.position, p2.transform.position);
        p3.transform.position = p;
        float area = Geometory3DMathUtils.GetAreaOfATriangle(p0.transform.position, p1.transform.position, p2.transform.position);
        Debug.Log(area);
        */
        
        // 2d test codes
        ccenter = Geometory2DMathUtils.GetCircumcenter(p0.transform.position, p1.transform.position, p2.transform.position);
        
        Vector2 p = Geometory2DMathUtils.GetDividingPoint(p0.transform.position, p1.transform.position,100.0f);
        p = Geometory2DMathUtils.GetIncenterPointOfATriangle(p0.transform.position, p1.transform.position, p2.transform.position);
        p3.transform.position = ccenter.center;

        float area = Geometory2DMathUtils.GetAreaOfATriangle(p0.transform.position, p1.transform.position, p2.transform.position);
        Debug.Log(area);
     
        Vector3 closest = GeometoryMath.GetClosestPointFromCenter(p, p0.transform.position, p1.transform.position, p2.transform.position);
        Debug.Log(closest);

        Vector3 furthest = GeometoryMath.GetFurthestPointFromCenter(p, p0.transform.position, p1.transform.position, p2.transform.position);
        Debug.Log(furthest);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(p0.transform.position, p1.transform.position, Color.red, 1.0f, false);
        Debug.DrawLine(p1.transform.position, p2.transform.position, Color.red, 1.0f, false);
        Debug.DrawLine(p2.transform.position, p0.transform.position, Color.red, 1.0f, false);

        if(ccenter != null)
        {
            DrawEllipse(p3.transform.position, p3.transform.forward, p3.transform.up, ccenter.radius, ccenter.radius, 20, Color.green, 1.0f);
        }
    }

    private static void DrawEllipse(Vector3 pos, Vector3 forward, Vector3 up, float radiusX, float radiusY, int segments, Color color, float duration = 0)
    {
        float angle = 0f;
        Quaternion rot = Quaternion.LookRotation(forward, up);
        Vector3 lastPoint = Vector3.zero;
        Vector3 thisPoint = Vector3.zero;

        for (int i = 0; i < segments + 1; i++)
        {
            thisPoint.x = Mathf.Sin(Mathf.Deg2Rad * angle) * radiusX;
            thisPoint.y = Mathf.Cos(Mathf.Deg2Rad * angle) * radiusY;

            if (i > 0)
            {
                Debug.DrawLine(rot * lastPoint + pos, rot * thisPoint + pos, color, duration);
            }

            lastPoint = thisPoint;
            angle += 360f / segments;
        }
    }
}
