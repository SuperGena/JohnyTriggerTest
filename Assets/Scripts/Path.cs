using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public Transform[] Pathes;
    public Transform GO;
    public float speed;

    public static Vector3 path2;
    public Vector3 path3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GO.transform.position != new Vector3(2f, 0.7f, 0f))
        {
            //GO.transform.position = QuadraticCurve(Pathes[0].position, Pathes[1].position, Pathes[2].position, speed * Time.deltaTime);

        }
            GO.transform.position = QuadraticCurve(new Vector3(-3f, 0.7f, 0f), new Vector3(-0.5f, 4f, 0f), new Vector3(2f, 0.7f, 0f), 1);
        path3 = path2;
    }

    public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return a + (b - a) * t;
    }

    public static Vector3 QuadraticCurve(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 p0 = Lerp(a, b, t);
        Vector3 p1 = Lerp(b, c, t);
        path2 = Lerp(p0, p1, t);
        
        return Lerp(p0, p1, t);
    }

}
