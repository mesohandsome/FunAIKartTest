using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide_with_Com : MonoBehaviour
{
    Rigidbody car;
    public float time = 2.0f;               // freeze time
    public bool collide = false;            // collide tag

    void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (collide == true)
        {
            car.constraints = RigidbodyConstraints.FreezeAll;       // freeze car
            time -= Time.deltaTime;                                 // minus deltaTime per frame
            
        }
        if(time <= 0)
        {
            car.constraints = RigidbodyConstraints.None;            // unfreeze car
            collide = false;
        }
    }

    void OnCollisionEnter(Collision collision)      // detect collide with computer
    {
        if (collision.gameObject.tag == "Com")
        {
            time = 2.0f;                            // set freeze time
            collide = true;
        }
    }
}
