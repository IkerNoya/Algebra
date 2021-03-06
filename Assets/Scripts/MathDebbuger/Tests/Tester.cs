﻿using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;
using plane;

public class Tester : MonoBehaviour
{
    public enum Ejercicio
    {
        uno,dos,tres,cuatro,cinco,seis,siete,ocho,nueve,diez, once
    }
    public Ejercicio ejercicio;
    public Vector3 a;
    public Vector3 b;
    Vec3 result;
    Vec3 multiplicacion;
    float timer = 0;
    float timer2 = 0;
    void Start()
    {
        VectorDebugger.EnableCoordinates();
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

}
