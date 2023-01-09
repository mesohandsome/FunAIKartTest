using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Threading;

public class Follow : MonoBehaviour
{
    public PathCreator pathCreator;

    public float speed = 0;
    public float totalTime;

    float distanceTravelled;


    void Update()
    {
        totalTime += Time.deltaTime;
        if(totalTime >= 3.5)
        {
            speed = 10;
        }

        distanceTravelled += speed * Time.deltaTime;
        
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);

        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}