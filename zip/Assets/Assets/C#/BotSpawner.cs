using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    public GameObject Bot;
    public float Speed;
    public static List<GameObject> BotList = new List<GameObject>();
    Map map;
    public float sizeMax;
    public float sizeMin;


    // Start is called before the first frame update
    void Start()
    {
        map = Map.instance;
        InvokeRepeating("BotGenerate", 0, Speed);

        for (int i = 0; i < 8; i++)
        {
            BotGenerate();
        }
    }

    // Update is called once per frame
    void BotGenerate()
    {
        Vector2 position = new Vector2(Random.Range(-map.Lim.x, map.Lim.x), Random.Range(-map.Lim.y, map.Lim.y));
        position /= 2;

        float x = Random.Range(sizeMax, sizeMin);

        Bot.transform.localScale = new Vector3(x, x, x / 3);

        var k = Instantiate(Bot, position, Quaternion.identity);
        BotList.Add(k);

    }
}
