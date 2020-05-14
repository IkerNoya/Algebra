using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;

public class Nave : MonoBehaviour
{
    Vector3 a;
    public float speed = 1;
    public GameObject bullet;

    void Start()
    {
        VectorDebugger.EnableCoordinates();

        Debug.Log(a.ToString());
        VectorDebugger.AddVector(a, Color.green, "La verde");

        VectorDebugger.EnableEditorView();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vec3 movement = new Vec3(horizontal, 0, vertical) * speed;
        transform.position += movement * Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate<GameObject>(bullet).transform.position = transform.position + new Vector3(0,0,4);
        }
    }
}
