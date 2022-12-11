using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject Player = collision.gameObject;
            int HowManyBalls = (int)Player.transform.localScale.x;

            Player.transform.localScale /= Player.transform.localScale.x;

            List<GameObject> instantiatedBalls = new List<GameObject>();
            instantiatedBalls.Add(Player);

            for (int i = 0; i < HowManyBalls; i++)
            {
                GameObject ball = Instantiate(Player, Player.transform.position, Quaternion.identity);
                instantiatedBalls.Add(Instantiate(ball));
            }

            int circleDegree = 360;

            float rotation = circleDegree / HowManyBalls;
            int Current_rotation = 0;

            for (int i = 0; i < instantiatedBalls.Count; i++)
            {
                GameObject B = instantiatedBalls[i];

                Current_rotation += 1;
                B.transform.rotation = Quaternion.Euler(0, 0, rotation * Current_rotation);

                B.GetComponent<CircleCollider2D>().enabled = false;
                // B.GetComponent<moove>.lockActions = false;

                B.GetComponent<SplitForce>().enabled = true; ;

            }

            Destroy(gameObject);
        }
    }

}