using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatEnemy : Actions
{
    public GameObject[] Enemy;

    // Start is called before the first frame update
    void Start()
    {
        UpdateEnemy();
    }

    // Update is called once per frame
    public override  void Update()
    {
        CheckEnemy();
    }

    public void UpdateEnemy()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void AddEnemy(GameObject ObEnemy)
    {
        List<GameObject> ListEnemy = new List<GameObject>();

        for (int i = 0; i < Enemy.Length; i++)
        {
            ListEnemy.Add(Enemy[i]);
        }
        ListEnemy.Add(ObEnemy);

        Enemy = ListEnemy.ToArray();
    }

    public void RemoveEnemy(GameObject ObEnemy)
    {
        List<GameObject> ListEnemy = new List<GameObject>();

        for (int i = 0; i < Enemy.Length; i++)
        {
            ListEnemy.Add(Enemy[i]);
        }
        ListEnemy.Remove(ObEnemy);

        Enemy = ListEnemy.ToArray();
    }
    

    public void CheckEnemy()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i] == this.gameObject || Enemy[i]==null)
            {
                continue;
            }

            Transform e = Enemy[i].transform;
            if(Vector2.Distance(transform.position, e.position)<=transform.localScale.x/3 && transform.localScale.x> e.transform.localScale.x)
            {
                RemoveEnemy(e.gameObject);
                transform.localScale += new Vector3(e.transform.localScale.x/3, e.transform.localScale.y/3, e.transform.localScale.z/3);
                Destroy(e.gameObject);
                
            }
        }
    }
    
}
