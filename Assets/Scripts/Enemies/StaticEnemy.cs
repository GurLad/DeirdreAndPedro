using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : Enemy
{
    public Vector2 SpawnRange = new Vector2(-3.25f, 3.25f);
    private void Start()
    {
        transform.position += new Vector3(Random.Range(SpawnRange.x, SpawnRange.y), 0, 0);
    }
}
