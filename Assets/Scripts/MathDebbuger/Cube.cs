using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using CustomMath;
using UnityEngine.UIElements;
using System.Threading;

public class Cube : MonoBehaviour
{
    public float angle;
    public Quaternion q1 = new Quaternion(1, 1, 1, 0);
    public QuaternionCustom ac;
    float t;

    // Update is called once per frame
    private void Start()
    {
        Debug.Log("UNITY: " + Quaternion.Euler(new Vec3(0, 90, 0)));
        Debug.Log("MIO: " + QuaternionCustom.Euler(new Vec3(0, 90, 0)));
        Debug.Log("UNITY- inverse : " + Quaternion.Inverse(new Quaternion(2,0,0,5)));
        Debug.Log("MIO - inverse : " + QuaternionCustom.Inverse(new QuaternionCustom(2, 0, 0, 5)));
        q1 = Quaternion.Euler(new Vec3(0,90,0));
        ac = QuaternionCustom.Euler(new Vec3(0, 90, 0));
    }
    void Update()
    {
        t += Time.deltaTime;
        if (t >= 1) t = 0;
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

        //transform.rotation = new Quaternion(z, 0, 0, w);
        //transform.rotation = QuaternionCustom.Euler(angle,0,0);
        transform.rotation = QuaternionCustom.Lerp(QuaternionCustom.Euler(0,90,0), QuaternionCustom.Euler(0,180,0), t);


    }
}
    