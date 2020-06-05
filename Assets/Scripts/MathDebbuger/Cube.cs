using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float angle;
    // Update is called once per frame
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
    