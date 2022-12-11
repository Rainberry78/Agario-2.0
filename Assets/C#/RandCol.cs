using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandCol : MonoBehaviour
{
    //Create the list
    public List<Material> Mats = new List<Material>();

    void Awake()
    {
        //Change the colour randomly
        GetComponent<Renderer>().material = Mats[Random.Range(0, Mats.Count)];
    }
}
