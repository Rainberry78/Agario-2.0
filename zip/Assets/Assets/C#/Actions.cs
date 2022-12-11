using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actions : MonoBehaviour
{
    public virtual void Update()
    {

    }

    /*

	public GameObject Mass;
	public Transform MassPosition;
	public float percentage = 0.1f;
	Eat PlayerMass;

	void Start()
	{
		PlayerMass = GetComponent<Eat>();
	}

	void Update()
	{
		if (transform.localScale.x <= 1)
		{
			return;
		}
		//transform.localScale -= new Vector3(percentage, percentage, percentage) * Time.deltaTime;

	}

	

	public void ThrowMass()
	{
		if (transform.localScale.x <= 1)
		{
			return;
		}
		Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float zr = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
		transform.rotation = Quaternion.Euler(0, 0, zr);
		GameObject b = Instantiate(Mass, MassPosition.position, Quaternion.identity);
		b.GetComponent<MassForce>().ApplyForce = true;
		//PlayerMass.AddMass(b);
		transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
	}

	
	public void Split()
	{
		if (transform.localScale.x <= 2)
		{
			return;
		}
		GameObject b = Instantiate(gameObject, transform.position, Quaternion.identity);
		b.GetComponent<SplitForce>().enabled = true;
		b.GetComponent<SplitForce>().SplitForce_Method();
	}
	
	*/

}
