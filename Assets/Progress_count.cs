using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress_count : MonoBehaviour
{
    GameObject[] progress_node;         // store all progress node
    GameObject kart;                    // get kart object
    Vector3 kart_position;              // get kart position
    Vector3 progress_node_position;     // get calculate progress node position

    int previous = 0;
    int current = 0;

    float diff_distance;                
    float progress;                     // current progress

    // Start is called before the first frame update
    void Start()
    {
        progress_node = GameObject.FindGameObjectsWithTag("Progress");
        kart = GameObject.Find("PAIAKart 1");
        // for (int i = 0; i < progress_node.Length; i++)
            // Debug.Log(progress_node[i]);
    }

    // Update is called once per frame
    void Update()
    {
        int Max = 1000000;
        kart_position = kart.transform.position;
        // Debug.Log(kart_position);

        for (int i = previous - 5; i < previous + 5; i++)
        {
            if (i < 0 || i > progress_node.Length-1)
            {
                continue;
            }

            Vector3 temp = progress_node[i].transform.position;

            diff_distance = (kart_position - temp).sqrMagnitude;

            // Debug.Log("第" + i + "個node的距離為" + diff_distance);
            // Debug.Log("第" + i + "個node的座標為" + temp);

            if (diff_distance < Max)
            {
                Max = Convert.ToInt32(diff_distance);
                current = i;
            }
        }
        // Debug.Log("current node = "+current);
        previous = current;
        Debug.Log(progress_node[current]);
        progress = (Convert.ToSingle(current) / Convert.ToSingle(progress_node.Length-1)) * 100;
        Debug.Log("Progress = " +progress +"%");
    }
    
}
