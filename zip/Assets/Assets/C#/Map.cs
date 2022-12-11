using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map instance;
    public Vector2 lim;
    public Color col;

    ~Map()
    {
        print("Map destroyed !");
    }

    public Vector2 Lim
    {
        get => lim;
        set => lim = value;
    }

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public override string ToString()
    {
        return "This is the map";
    }
        

    private void OnDrawGizmos()
    {
        print("lsdkfjlskdfj");
        Gizmos.color = col;
        Gizmos.DrawWireCube(transform.position, Lim);
    }
}
