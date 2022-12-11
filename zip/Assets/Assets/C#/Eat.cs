using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Eat : Actions
{
	public string Tag;
	public float SizeIncrease;

    
    //public Text Letters;

    //int Score = 0;

    void OnTriggerEnter(Collider other)
	{
		//print("blabalan");
		if (other.gameObject.tag == Tag)
		{
			transform.localScale += new Vector3(SizeIncrease, SizeIncrease, 0.03f);
			FoodS.foodList.Remove(other.gameObject);
			Destroy(other.gameObject);
			//Score += 10;
			//Letters.text = "Score: " + Score;
		}

		if (other.gameObject.tag == "Enemy") 
        {
			print("pqlsplspl");
			if (transform.localScale.x > other.gameObject.transform.localScale.x)
			{
				float dist = Vector3.Distance(other.gameObject.transform.position, this.gameObject.transform.position);
				print(dist);
				if (true)
				{
					//RemoveEnemy(other.gameObject);
					transform.localScale += new Vector3(other.gameObject.transform.localScale.x / 3, other.gameObject.transform.localScale.y / 3, other.gameObject.transform.localScale.z / 3);
					Destroy(other.gameObject);
				}
			}
		}
	}
	/*
	public void CheckMass()
	{
		for (int i = 0; i < Mass.Length; i++)
		{
			if (Mass[i] == null)
			{
				OnTriggerEnter();
				return;
			}
			Transform m = Mass[i].transform;
			if (Vector2.Distance(transform.position, m.position) <= transform.localScale.x / 2)
			{
				RemoveMass(m.gameObject);
				Eat();
				Destroy(m.gameObject);
			}
		}
	}
	*/
}
