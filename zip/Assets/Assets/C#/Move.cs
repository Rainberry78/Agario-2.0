using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Actions
{
    //public float Speed;
    public float mS;
    Map map;
    public bool lockActions = false;
    //Actions action = new Actions();
    //Actions actions;


    private void Start()
    {
        map = Map.instance;
        //actions = GetComponent<Actions>();
    }

    // Update is called once per frame
    public override void Update()
    {
        //float speed_ = Speed / transform.localScale.x;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction.x = Mathf.Clamp(direction.x, map.Lim.x * -1 / 2, map.Lim.x / 2);
        direction.y = Mathf.Clamp(direction.y, map.Lim.y * -1 / 2, map.Lim.y / 2);

        //float t = transform.localScale.x;
        transform.position = Vector2.MoveTowards(transform.position, direction, mS * Time.deltaTime/transform.localScale.z);

        if (lockActions)
        {
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //action.ThrowMass();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //action.Split();
        }

    }

}
