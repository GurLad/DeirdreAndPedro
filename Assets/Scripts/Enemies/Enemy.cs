using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Vector2 SpawnRange = new Vector2(-3.25f, 3.25f);
    public bool OneTime;
    public GameObject Explosion;
    private int positive;
    private float life = 20;
    protected virtual void Start()
    {
        transform.position += new Vector3(Random.Range(SpawnRange.x, SpawnRange.y), 0, 0);
        positive = (int)Mathf.Sign(transform.position.y);
    }
    protected virtual void Update()
    {
        life -= Time.deltaTime;
        if (life <= 0 || positive != (int)Mathf.Sign(transform.position.y))
        {
            Destroy(gameObject);
        }
    }
    public void AfterCollision()
    {
        if (OneTime)
        {
            GameObject explosion = Instantiate(Explosion);
            explosion.transform.position = gameObject.transform.position;
            explosion.SetActive(true);
            Destroy(gameObject);
        }
    }
}
