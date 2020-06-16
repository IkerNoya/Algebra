using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using CustomMath;
using UnityEngine.UIElements;

public class Cube : MonoBehaviour
{
    public float angle;
    Quaternion q1 = new Quaternion(1, 1, 1, 0);
    QuaternionCustom ac;
    // Update is called once per frame
    private void Start()
    {
        Debug.Log("UNITY: " + Quaternion.Angle(new Quaternion(1, 0, 0,0), new Quaternion(0, 0, 0, 0)));
        Debug.Log("MIO: " + (QuaternionCustom.Angle(new Quaternion(1, 0, 0, 0), new Quaternion(0, 0, 0, 0))));
        Debug.Log("UNITY- inverse : " + Quaternion.Inverse(new Quaternion(2,0,0,5)));
        Debug.Log("MIO - inverse : " + QuaternionCustom.Inverse(new QuaternionCustom(2, 0, 0, 5)));
    }
    void Update()
    {
        //Descomentar para ver cada ejemplo
        //Rotaciones con binomio al cuadrado
        //float VecX = (1 / Mathf.Sqrt(2));
        //float Vecy = (1 / Mathf.Sqrt(2));
        //float x = transform.position.x * VecX - transform.position.y * Vecy;
        //float y = transform.position.x * Vecy + transform.position.y * VecX;
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    transform.position = new Vector3(x, y, 0);
        //}
        //-------------------------------------
        //Inicio cuaterniones
        //cos alfa/2 + i * sen alfa/2 + j * sen alfa/2 + K * sen alfa/2
        angle += 10;
        float w = Mathf.Cos(Mathf.Deg2Rad*angle* 0.5f);
        float z = Mathf.Sin(Mathf.Deg2Rad * angle * 0.5f);

        transform.rotation = new Quaternion(z, 0, 0, w);



    }
}
    