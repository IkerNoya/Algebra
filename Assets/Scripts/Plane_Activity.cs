using CustomMath;
using plane;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Activity : MonoBehaviour
{
    public GameObject cube;
    public List<GameObject> Walls = new List<GameObject>();
    Planes wallXPos;
    Planes wallXNeg;
    Planes wallYPos;
    Planes wallYNeg;
    Planes wallZPos;
    Planes wallZNeg;

    Plane test;
    Plane test2;
    Plane test3;
    Plane test4;
    Plane test5;
    Plane test6;

    void Start()
    {
        wallYNeg = new Planes(new Vec3(Walls[2].transform.position - Walls[1].transform.position), Walls[1].transform.position);
        wallXNeg = new Planes(new Vec3(Walls[2].transform.position - Walls[1].transform.position), Walls[1].transform.position);
        wallXPos = new Planes(new Vec3(Walls[1].transform.position - Walls[2].transform.position), Walls[2].transform.position);
        wallZPos = new Planes(new Vec3(Walls[2].transform.position - Walls[1].transform.position), Walls[1].transform.position);
        wallZNeg = new Planes(new Vec3(Walls[2].transform.position - Walls[1].transform.position), Walls[1].transform.position);
        wallYPos = new Planes(new Vec3(Walls[2].transform.position - Walls[1].transform.position), Walls[1].transform.position);

        test = new Plane(new Vec3(Walls[2].transform.position - Walls[1].transform.position), Walls[1].transform.position);
        test2 = new Plane(new Vec3(Walls[1].transform.position - Walls[2].transform.position), Walls[2].transform.position);
        test3 = new Plane(new Vec3(Walls[2].transform.position - Walls[1].transform.position), Walls[1].transform.position);
        test4 = new Plane(new Vec3(Walls[2].transform.position - Walls[1].transform.position), Walls[1].transform.position);
        test5 = new Plane(new Vec3(Walls[2].transform.position - Walls[1].transform.position), Walls[1].transform.position);
        test6 = new Plane(new Vec3(Walls[2].transform.position - Walls[1].transform.position), Walls[1].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        DrawPlaneAtPoint(test, Walls[1].transform.position, 10, Color.red, 10.0f, true);
        DrawPlaneAtPoint(test2, Walls[2].transform.position, 10, Color.red, 10.0f, true);
        Debug.Log("IzquierdaX: " + wallXNeg.GetSide(cube.transform.position));
        Debug.Log("DerechaX: " + wallXPos.GetSide(cube.transform.position));

    }

    public static void DrawPlane(Vector3 a, Vector3 b, Vector3 c, float size,
Color color, float duration = 0f, bool depthTest = true)
    {

        var plane = new Plane(a, b, c);
        var centroid = (a + b + c) / 3f;

        DrawPlaneAtPoint(plane, centroid, size, color, duration, depthTest);
    }

    // Draws the portion of the plane closest to the provided point, 
    // with an altitude line colour-coding whether the point is in front (cyan)
    // or behind (red) the provided plane.
    public static void DrawPlaneNearPoint(Plane plane, Vector3 point, float size, Color color, float duration = 0f, bool depthTest = true)
    {
        var closest = plane.ClosestPointOnPlane(point);
        Color side = plane.GetSide(point) ? Color.cyan : Color.red;
        Debug.DrawLine(point, closest, side, duration, depthTest);

        DrawPlaneAtPoint(plane, closest, size, color, duration, depthTest);
    }
    static void DrawPlaneAtPoint(Plane plane, Vector3 center, float size, Color color, float duration, bool depthTest)
    {
        var basis = Quaternion.LookRotation(plane.normal);
        var scale = Vector3.one * size / 10f;

        var right = Vector3.Scale(basis * Vector3.right, scale);
        var up = Vector3.Scale(basis * Vector3.up, scale);

        for (int i = -5; i <= 5; i++)
        {
            Debug.DrawLine(center + right * i - up * 5, center + right * i + up * 5, color, duration, depthTest);
            Debug.DrawLine(center + up * i - right * 5, center + up * i + right * 5, color, duration, depthTest);
        }
    }
}
