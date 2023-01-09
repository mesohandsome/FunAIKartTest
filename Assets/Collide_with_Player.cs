using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide_with_Player : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)      // detect collide with player
    {
        if(collision.gameObject.tag == "Player")
        {
            // print("collide with player!");
            this.gameObject.SetActive(false);
        }
    }
}
