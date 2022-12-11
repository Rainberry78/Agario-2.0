using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ia : MonoBehaviour
{
    //private static List<ia> ias = new List<ia>();
    //private ia attacked;
    private GameObject food;
    public GameObject[] players;
    public List<GameObject> pl = new List<GameObject>();//faire liste de joueur 
    //faire spawner de bot avec position random et taille random entre 1 et 5
    Map map;
    Vector3 direction;
    public float speed;
    float amount;

    #region Comm

    // Start is called before the first frame update
    /*void Start()
    {
        ias.Add(this);
        map = Map.instance;
        
    }

    // Update is called once per frame
    void Update()
    {
        ia attacker = null;
        foreach (var ia in ias)
        {
            if (ia.attacked = this)
            {
                attacker = ia;
            }
        }*/

    /*int k = 0;
    k++;

}
*/


    //if (attacker != null)
    //{
    //fuir -> aller vers le plus gros et mettre un moins


    //}
    //else
    //{
    //chercher a manger 

    //}
    //}

    /*
      public void MoveIA()
    {
        //Vector2 direction = new Vector2(transform.position.x, transform.position.y);

        //direction.x = Mathf.Clamp(direction.x + x, map.lim.x * -1 / 2, map.lim.x / 2);
        //direction.y = Mathf.Clamp(direction.y + y, map.lim.y * -1 / 2, map.lim.y / 2);
        //var x = FoodS.foodList[UnityEngine.Random.Range(0, FoodS.foodList.Count - 1)];
    }

     */

    #endregion

    void Start()
    {
        map = Map.instance;
        players = GameObject.FindGameObjectsWithTag("Enemy");
        print(string.Join(";",(IEnumerable<GameObject>) players));//LINQ
    }

    public void Update()
    {
        iaBrain();
    }

    public void MoveIA()
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
        food = FoodS.foodList[UnityEngine.Random.Range(0, FoodS.foodList.Count - 1)];
    }


    void iaBrain()
    {
        MoveIA();

        for (int i = 0; i < players.Length; i++)
        {
            if(players[i]==this.gameObject || players[i]==null)
            {
                continue;
            }

            amount = ((players[i].transform.position) - (transform.position)).magnitude;//distance avec un ennemi
            direction = ((players[i].transform.position) - (transform.position)).normalized;//length=1

            if (amount < 5 && amount > 1 && transform.localScale.x < players[i].transform.localScale.x)
            {
                //escape
                Dodge();
            }

            if (amount < 5 && transform.localScale.x > players[i].transform.localScale.x)
            {
                //follow an other player
                Hunt();
            }
        }
    }

    void Dodge()
    {
        transform.position += -direction * speed * Time.deltaTime;
        
    }

    void Hunt()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    
}
