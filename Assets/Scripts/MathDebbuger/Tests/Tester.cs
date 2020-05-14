using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;
using plane;

public class Tester : MonoBehaviour
{
    public enum Ejercicio
    {
        uno,dos,tres,cuatro,cinco,seis,siete,ocho,nueve,diez
    }

    public Ejercicio ejercicio;
    public Vector3 a;
    public Vector3 b;
    Vec3 result;
    Vec3 multiplicacion;
    float timer = 0;
    float timer2 = 0;
    Planes planes;
    Plane plane;
    public Vector3 planeA;
    public Vector3 planeB;
    public Vector3 planeC;
    public Vector3 prueba = -Vector3.one;
    void Start()
    {
        VectorDebugger.EnableCoordinates();
        planeA = new Vector3(10, 20, 5);
        planeB = new Vector3(10, 0, 0);
        planeC = new Vector3(0, 4, 3);

        plane = new Plane(planeA, planeB, planeC);
        planes = new Planes(planeA, planeB, planeC);
        Debug.Log(a.ToString());
        VectorDebugger.AddVector(a, Color.green, "La verde");
        Debug.Log(b.ToString());
        VectorDebugger.AddVector(b, Color.blue, "La azul");
        Debug.Log(result.ToString());
        VectorDebugger.AddVector(result, Color.red, "La roja");


        VectorDebugger.EnableEditorView();

    }

    // Update is called once per frame
    void Update()
    {
        Vec3 A = new Vec3(a);
        Vec3 B = new Vec3(b);
        Debug.Log(plane.ToString());
        Debug.Log(planes.ToString());
        Debug.Log(plane.GetDistanceToPoint(prueba));
        Debug.Log(planes.GetDistanceToPoint(prueba));
        multiplicacion = new Vec3(a);
        multiplicacion.Scale(B);
        if (timer >= 1.0f) timer = 0;
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.O))
        {
            VectorDebugger.TurnOffVector("elAzul");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            VectorDebugger.TurnOnVector("elAzul");
        }

        VectorDebugger.UpdatePosition("La verde", A);
        VectorDebugger.UpdatePosition("La azul", B);
        switch (ejercicio) 
        {
            case Ejercicio.uno:
                VectorDebugger.UpdatePosition("La roja", new Vec3(a + b));
                break;
            case Ejercicio.dos:
                VectorDebugger.UpdatePosition("La roja", new Vec3(b - a));
                break;
            case Ejercicio.tres:
                result = multiplicacion;
                VectorDebugger.UpdatePosition("La roja", new Vec3(multiplicacion));
                break;
            case Ejercicio.cuatro:
                VectorDebugger.UpdatePosition("La roja", new Vec3(Vec3.Cross(A,B)));
                break;
            case Ejercicio.cinco:
                VectorDebugger.UpdatePosition("La roja", Vec3.Lerp(B, A, timer));
                break;
            case Ejercicio.seis:
                VectorDebugger.UpdatePosition("La roja", Vec3.Max(A,B));
                break;
            case Ejercicio.siete:
                VectorDebugger.UpdatePosition("La roja", Vec3.Project(A,B));
                break;
            case Ejercicio.ocho:
                VectorDebugger.UpdatePosition("La roja", new Vec3(a + b));
                break;
            case Ejercicio.nueve:
                VectorDebugger.UpdatePosition("La roja", Vec3.Reflect(A,B));
                break;
            case Ejercicio.diez:
                VectorDebugger.UpdatePosition("La roja", Vec3.LerpUnclamped(A,B,timer2));
                break;

        } 
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
