using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public PlayerController Player;
    public Sprite[] Sprites;
    public int Health;
    public GameObject DestroyParticle;
    private SpriteRenderer renderer;
    private Rigidbody2D rigidbody;
    private Vector3 initPos;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        initPos = transform.localPosition;
    }
    private void Update()
    {
        rigidbody.velocity = Vector2.zero;
        transform.localPosition = initPos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Player.Slave = false;
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.AfterCollision();
            if (!enemy.OneTime)
            {
                GameObject explosion = Instantiate(DestroyParticle);
                explosion.transform.position = enemy.transform.position;
                explosion.SetActive(true);
                Destroy(enemy.gameObject);
            }
            if (--Health <= 0)
            {
                GameObject explosion = Instantiate(DestroyParticle);
                explosion.transform.position = gameObject.transform.position;
                explosion.SetActive(true);
                Destroy(gameObject);
                return;
            }
            renderer.sprite = Sprites[Health - 1];
        }
    }
    public void Init(int h)
    {
        Health = h;
        renderer.sprite = Sprites[Health - 1];
    }
}
