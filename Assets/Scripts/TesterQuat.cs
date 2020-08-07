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
    float newAngle;
    public GameObject target;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public GameObject target5;
    Vector3 initialPos1;
    Vector3 initialPos2;
   
    private void Start()
    {
        newAngle = 0;
        initialPos1 = target4.transform.position;
        initialPos2 = target5.transform.position;
    }
    private void Update()
    {
        newAngle += angle;
        switch (ejercicios)
        {
            case Ejercicios.uno:
                target4.SetActive(false);
                target.SetActive(true);
                target2.SetActive(false);
                target3.SetActive(false);
                target.transform.rotation = QuaternionCustom.Euler(0,newAngle,0);
                break;
            case Ejercicios.dos:
                target.transform.rotation = QuaternionCustom.Euler(0, newAngle, 0);
                target2.SetActive(true);
                target3.SetActive(true);
                break;
            case Ejercicios.tres:
                target4.transform.rotation *= Quaternion.Euler(0, angle, angle);
                target5.transform.rotation *= Quaternion.Euler(0, -angle, -angle);
                target.SetActive(false);
                target4.SetActive(true);
                break;
        }
        
    }
}
