using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Actions
{
    public float mS;
    Map map;

    private void Start()
    {
        map = Map.instance;
    }

    // Update is called once per frame
    public override void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction.x = Mathf.Clamp(direction.x, map.Lim.x * -1 / 2, map.Lim.x / 2);
        direction.y = Mathf.Clamp(direction.y, map.Lim.y * -1 / 2, map.Lim.y / 2);

        transform.position = Vector2.MoveTowards(transform.position, direction, mS * Time.deltaTime/transform.localScale.z);
    }

}