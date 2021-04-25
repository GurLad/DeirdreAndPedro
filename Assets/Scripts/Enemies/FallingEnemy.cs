using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemy : Enemy
{
    public float Speed;
    protected override void Start()
    {
        base.Start();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, Speed);
    }
}
