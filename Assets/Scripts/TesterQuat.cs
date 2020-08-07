using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using MathDebbuger;

public class TesterQuat : MonoBehaviour
{
    public enum Ejercicios
    {
        uno, dos, tres
    }
    public Ejercicios ejercicios;
    public float angle;
    public Vector3 a;
    float newAngle;
    public GameObject target;
    public GameObject t;
   
    private void Start()
    {
        a = new Vec3(5, 0, 8);
        newAngle = 0;
        //EjerciciosAlgebra.VectorDebugger.EnableCoordinates();
        //EjerciciosAlgebra.VectorDebugger.AddVector(a, Color.red, "La Roja");
        //EjerciciosAlgebra.VectorDebugger.EnableEditorView();
    }
    private void Update()
    {
        Debug.Log("mine:" + QuaternionCustom.Slerp(transform.rotation, t.transform.rotation, 0.85f));
        Debug.Log("UNITY:" + Quaternion.Slerp(transform.rotation, t.transform.rotation, 0.85f));
        newAngle += angle;
        Vec3 A = new Vec3(a);
        //EjerciciosAlgebra.VectorDebugger.UpdatePosition("La Roja", A);
        //VectorDebugger.GetVectorsPositions("La Roja");
        QuaternionCustom q1;
        switch (ejercicios)
        {
            case Ejercicios.uno:
                target.transform.rotation = Quaternion.Euler(0,newAngle,0);
                break;
            case Ejercicios.dos:
                break;
            case Ejercicios.tres:
                break;
        }
        
    }
}
