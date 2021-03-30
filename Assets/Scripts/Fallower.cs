using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Fallower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTrvelled;


    void Update()
    {
        //if (pathCreator.path.GetPoint(2)  == pathCreator.path. )
        //{

        //}
        distanceTrvelled += speed * Time.deltaTime;

        Vector3 movement = new Vector3
            (
             pathCreator.path.GetPointAtDistance(distanceTrvelled).x,
             pathCreator.path.GetPointAtDistance(distanceTrvelled).y - transform.localScale.y,
             0
            );
        transform.position = movement;

    }
}
