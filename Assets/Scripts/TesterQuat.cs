using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
using MathDebbuger;
using EjerciciosAlgebra;

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
    public GameObject t; 
    private void Start()
    {
        a = new Vec3(5, 0, 8);
        newAngle = 0;
        EjerciciosAlgebra.VectorDebugger.EnableCoordinates();
        EjerciciosAlgebra.VectorDebugger.AddVector(a, Color.red, "La Roja");
        EjerciciosAlgebra.VectorDebugger.EnableEditorView();
    }
    private void Update()
    {

        newAngle += angle;
        Vec3 A = new Vec3(a);
        EjerciciosAlgebra.VectorDebugger.UpdatePosition("La Roja", A);
        QuaternionCustom q1;
        switch (ejercicios)
        {
            case Ejercicios.uno:
                t.transform.rotation = Quaternion.Euler(90,newAngle,0);
                break;
            case Ejercicios.dos:
                break;
            case Ejercicios.tres:
                break;
        }
        
    }
}
