using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodS : MonoBehaviour
{
	public GameObject Food;
	public float frequencyOccurrence;
	public static List<GameObject> foodList = new List<GameObject>();
	int nbFoodStart;
	Map map;
	
	// Start is called before the first frame update
	void Start()
	{
		map = Map.instance;
		nbFoodStart = BotSpawner.nbBotStart_c*2;
		InvokeRepeating("FoodGenerate", 0, frequencyOccurrence);

        for (int i = 0; i < nbFoodStart; i++)
        {
			FoodGenerate();
        }
	}

	void FoodGenerate()
	{
		Vector2 position = new Vector2(Random.Range(-map.Lim.x, map.Lim.x), Random.Range(-map.Lim.y, map.Lim.y));
		position /= 2;

		var x = Instantiate(Food, position, Quaternion.identity);
		foodList.Add(x);

	}	
}
