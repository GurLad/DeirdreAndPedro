using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public Vector2 SpawnRange;
    public Vector2 SpeedRange;
    private void Start()
    {
        transform.position += new Vector3(Random.Range(SpawnRange.x, SpawnRange.y), 0);
        float speed = Random.Range(SpeedRange.x, SpeedRange.y);
        if (Random.Range(0, 2) == 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            speed *= -1;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
    private void Update()
    {
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
