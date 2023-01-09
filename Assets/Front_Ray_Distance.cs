using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Front_Ray_Distance : MonoBehaviour
{
    RaycastHit hit_forward;
    RaycastHit hit_right;
    RaycastHit hit_left;
    RaycastHit hit_forward_right;
    RaycastHit hit_forward_left;

    // Update is called once per frame
    void Update()
    {
        Ray ray_forward = new Ray(transform.position, transform.forward);                               // Forward ray
        Ray ray_right = new Ray(transform.position, transform.right);                                   // Right ray
        Ray ray_left = new Ray(transform.position, -transform.right);                                   // Left ray 
        Ray ray_forward_right = new Ray(transform.position, transform.forward + transform.right);       // Forward right ray
        Ray ray_forward_left = new Ray(transform.position, transform.forward - transform.right);        // Forward left ray

        
        if (Physics.Raycast(ray_forward, out hit_forward))
        {
            Debug.Log("Forward distance = " + hit_forward.distance + " Object = " + hit_forward.transform.name);
        }

        if (Physics.Raycast(ray_right, out hit_right))
        {
            Debug.Log("Right distance = " + hit_right.distance + " Object = " + hit_right.transform.name);
        }

        if (Physics.Raycast(ray_left, out hit_left))
        {
            Debug.Log("Left distance = " + hit_left.distance + " Object = " + hit_left.transform.name);
        }

        if (Physics.Raycast(ray_forward_right, out hit_forward_right))
        {
            Debug.Log("Forward_right distance = " + hit_forward_right.distance + " Object = " + hit_forward_right.transform.name);
        }
        
        if (Physics.Raycast(ray_forward_left, out hit_forward_left))
        {
            Debug.Log("Forward_left distance = " + hit_forward_left.distance + " Object = " + hit_forward_left.transform.name);
        }

    }
}
