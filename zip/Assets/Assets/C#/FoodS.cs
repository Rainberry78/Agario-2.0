using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodS : MonoBehaviour
{
	public GameObject Food;
	public float Speed;
	public static List<GameObject> foodList = new List<GameObject>();

	Map map;

	// Start is called before the first frame update
	void Start()
	{
		map = Map.instance;
		InvokeRepeating("FoodGenerate", 0, Speed);

        for (int i = 0; i < 10; i++)//mettre le double du nb de bot qui spawn
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
