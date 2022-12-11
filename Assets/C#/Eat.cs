using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Eat : Actions
{
	public string Tag;
	public float SizeIncrease;
   
    void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == Tag)
		{
			transform.localScale += new Vector3(SizeIncrease, SizeIncrease, 0.03f);
			FoodS.foodList.Remove(other.gameObject);
			Destroy(other.gameObject);
		}	
	}
}
