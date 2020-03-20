using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;

public class Tester : MonoBehaviour
{
    void Start()
    {
        VectorDebugger.EnableCoordinates();

        Vec3 test = new Vec3(10.0f, 10.0f, 10.0f);
        Vec3 test2 = new Vec3(7.0f, 7.0f, 7.0f);
        Vec3 resta = new Vec3(test - test2);
        Vec3 invertir = new Vec3(-resta);
        Vec3 mult = new Vec3(test * 2.0f);
        Vec3 mult2 = new Vec3(2.0f * test);
        VectorDebugger.AddVector(test, Color.red, "red one");
        VectorDebugger.AddVector(test2, Color.blue, "blue one");
        VectorDebugger.AddVector(resta, Color.green, "green one");
        VectorDebugger.AddVector(invertir, Color.yellow, "yellow one");
        VectorDebugger.AddVector(mult, Color.gray, "gray one");
        VectorDebugger.AddVector(mult2, Color.black, "black one");
        Debug.Log((resta).ToString());
        Debug.Log((invertir).ToString());
        Debug.Log((mult).ToString());
        Debug.Log((mult2).ToString());
        VectorDebugger.EnableEditorView();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            VectorDebugger.TurnOffVector("elAzul");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            VectorDebugger.TurnOnVector("elAzul");
        }
    }
}
