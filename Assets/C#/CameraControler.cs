using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public GameObject player;
    private float previousScale=1;//scale of the player at the start
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        if(player.transform.localScale.x != previousScale)
        {
            cam.orthographicSize += (player.transform.localScale.x-previousScale)*0.05f*16.6666667f;
            previousScale = player.transform.localScale.x;            
        }        
    }
}
