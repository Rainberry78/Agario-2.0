using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    public GameObject Bot;
    public float timeSpawn;//frequency of spawn
    public static List<GameObject> BotList;
    Map map;
    public float sizeMax;
    public float sizeMin;
    public int nbBotStart;
    public static int nbBotStart_c=8;
    
    // Start is called before the first frame update
    void Start()
    {
        //nbBotStart_c = nbBotStart;
        map = Map.instance;
        --nbBotStart;
        BotList = new List<GameObject>();
        
        for (int i = 0; i < nbBotStart; i++)
        {
            BotGenerateStart();
        }

        InvokeRepeating("BotGenerate", 0, timeSpawn);
    }

    // Update is called once per frame
    void BotGenerate()
    {
        Vector2 position = new Vector2(Random.Range(-map.Lim.x, map.Lim.x), Random.Range(-map.Lim.y, map.Lim.y));
        position /= 2;

        float x = Random.Range(sizeMax, sizeMin);

        Bot.transform.localScale = new Vector3(x, x, x / 3);

        Instantiate(Bot, position, Quaternion.identity);
        
        BotList.Add(Bot);

    }

    void BotGenerateStart()//avoid spawn kills
    {
        float a = Random.Range(-map.Lim.x, map.Lim.x);
        float b = Random.Range(-map.Lim.y, map.Lim.y);

        while (a >-5 && a < 5)
        {
            a = Random.Range(-map.Lim.x, map.Lim.x);
        }
        while (b > -5 && b < 5)
        {
            b = Random.Range(-map.Lim.x, map.Lim.x);
        }

        Vector2 position = new Vector2(a,b);
        position /= 2;

        float x = Random.Range(sizeMax, sizeMin);

        Bot.transform.localScale = new Vector3(x, x, x / 3);

        Instantiate(Bot, position, Quaternion.identity);

        BotList.Add(Bot);

    }

}
