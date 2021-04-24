using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public bool OneTime;
    public GameObject Explosion;
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
