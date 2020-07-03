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
    public QuaternionCustom qP1;
    public QuaternionCustom qP2;
    public Quaternion qP3;
    public Quaternion qP4;
    public Transform target;
    bool rotate = false;

    // Update is called once per frame
    private void Start()
    {
        qP1 = new QuaternionCustom(0, 180, 0, 5);
        qP2 = new QuaternionCustom(0, 90, 0, 5);
        qP3 = new Quaternion(0, 180, 0, 5);
        qP4 = new Quaternion(0,90, 0, 5);
    }
    void Update()   
    {
        t += Time.deltaTime ;
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
        //transform.rotation = QuaternionCustom.Lerp(QuaternionCustom.Euler(0,90,0), QuaternionCustom.Euler(0,180,0), t);
        Vec3 a = Vec3.Up;
        Vec3 b = Vec3.Forward;
        Debug.Log("UNITY: " + Quaternion.Slerp(new Quaternion(10,0,0,1), new Quaternion(0, 10, 0, 1), 0.5f));
        Debug.Log("MIO: " + QuaternionCustom.Slerp(new QuaternionCustom(10, 0, 0, 1), new QuaternionCustom(0, 10, 0, 1), 0.5f));
        if (Input.GetKeyDown(KeyCode.Space))
            rotate = true;
        if(rotate)
            transform.rotation = QuaternionCustom.Slerp(transform.rotation, target.rotation, t);

    }
}
    