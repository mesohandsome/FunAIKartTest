using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Ray_Distance : MonoBehaviour
{
    RaycastHit hit_back;
    RaycastHit hit_back_right;
    RaycastHit hit_back_left;

    // Update is called once per frame
    void Update()
    {
        Ray ray_back = new Ray(transform.position, -transform.forward);                               // Back ray 
        Ray ray_back_right = new Ray(transform.position, -transform.forward + transform.right);       // Back right ray
        Ray ray_back_left = new Ray(transform.position, -transform.forward - transform.right);        // Back left ray

        if (Physics.Raycast(ray_back, out hit_back))
        {
            Debug.Log("Back distance = " + hit_back.distance + " Object = " + hit_back.transform.name);
        }
        
        if (Physics.Raycast(ray_back_right, out hit_back_right))
        {
            Debug.Log("Back_right distance = " + hit_back_right.distance + " Object = " + hit_back_right.transform.name);
        }

        if (Physics.Raycast(ray_back_left, out hit_back_left))
        {
            Debug.Log("Back_left distance = " + hit_back_left.distance + " Object = " + hit_back_left.transform.name);
        }
    }
}
