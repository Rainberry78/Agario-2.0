using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ia : MonoBehaviour
{
    private GameObject food;
    public GameObject[] players;
    Vector3 direction;
    public float speed;
    float amount;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Enemy");

        print(string.Join(";", (IEnumerable<GameObject>)players));//LINQ
    }

    public void Update()
    {
        iaBrain();
    }

    public void EatIA()
    {
        if (food != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, food.transform.position, speed * Time.deltaTime / transform.localScale.z);
        }
        else
        {
            SelectFood();
        }
    }

    public void SelectFood()
    {
        food = FoodS.foodList[UnityEngine.Random.Range(0, FoodS.foodList.Count)];
    }


    void iaBrain()
    {
        bool hasmoved = false;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == this.gameObject || players[i] == null){
                continue;
            }

            amount = ((players[i].transform.position) - (transform.position)).magnitude - (players[i].transform.localScale.x / 2) - (transform.localScale.x) / 2;//distance from an enemy
            direction = ((players[i].transform.position) - (transform.position)).normalized;//length=1

            if (amount < 5 && transform.localScale.x < players[i].transform.localScale.x)
            {
                //escape
                hasmoved = true;
                Dodge();
            }

            if (amount < 4 && transform.localScale.x > players[i].transform.localScale.x)
            {
                //follow an other player
                hasmoved = true;
                Hunt();
            }
        }
        if(hasmoved==false)
        {
            EatIA();
        }
    }

    void Dodge()
    {
        transform.position += -direction * speed * Time.deltaTime / transform.localScale.z;
    }

    void Hunt()
    {
        transform.position += direction * speed * Time.deltaTime / transform.localScale.z;
    }
}
