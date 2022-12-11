using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitForce : MonoBehaviour
{
	public float LoseSpeed;
	public float DefaultSpeed;
	public float Speed;
	public bool ApplySplitForce = false;

	public void SplitForce_Method()
	{
		GetComponent<CircleCollider2D>().enabled = false;
		GetComponent<Move>().lockActions = true;
		Vector2 dir = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float Angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;
		transform.rotation = Quaternion.Euler(0, 0, Angle);
		Speed = DefaultSpeed;
		ApplySplitForce = true;
	}

	void Update()
	{
		if (ApplySplitForce == false)
		{
			enabled = false;
			return;
		}
		transform.Translate(Vector2.up * Speed * Time.deltaTime);
		Speed -= LoseSpeed * Time.deltaTime;
		if (Speed <= 0)
		{
			GetComponent<CircleCollider2D>().enabled = true;
			GetComponent<Move>().lockActions = false;
			enabled = false;
		}
	}
}