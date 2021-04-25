using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{
    public Vector2 SpeedRange;
    protected override void Start()
    {
        base.Start();
        float speed = Random.Range(SpeedRange.x, SpeedRange.y);
        if (Random.Range(0, 2) == 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            speed *= -1;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
    protected override void Update()
    {
        base.Update();
        if (transform.position.x > SpawnRange.y)
        {
            transform.position = new Vector3(SpawnRange.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < SpawnRange.x)
        {
            transform.position = new Vector3(SpawnRange.y, transform.position.y, transform.position.z);
        }
    }
}
