using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Horizontal movement vars")]
    public float Speed;
    public float Force;
    public float ResetForce;
    public float Accuracy;
    [Header("Stuff")]
    public float YSpeed;
    public PlayerController OtherPlayer;
    [SerializeField]
    private bool _slave = false;
    public bool Slave
    {
        get
        {
            return _slave;
        }
        set
        {
            _slave = value;
            rigidbody.isKinematic = Slave;
            OtherPlayer._slave = !Slave;
            OtherPlayer.rigidbody.isKinematic = !Slave;
        }
    }
    private Rigidbody2D rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!Slave)
        {
            Move(new Vector2(Input.GetAxis("Horizontal"), YSpeed));
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
            Vector3 target = OtherPlayer.transform.position;
            target.y *= -1;
            transform.position = target;
        }
    }
    private Vector2 Move(Vector2 target)
    {
        float tempY = target.y;
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
        if (rigidbody.velocity.magnitude > Speed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * Speed;
        }
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, tempY);
        Vector2 TargetVelocity = target.normalized * Speed;
        if (TargetVelocity == Vector2.zero)
        {
            Vector2 force = -rigidbody.velocity * ResetForce;
            force.y = 0;
            rigidbody.AddForce(force);
            return Vector2.zero;
        }
        TargetVelocity.y = rigidbody.velocity.y;
        if ((rigidbody.velocity - TargetVelocity).magnitude <= Accuracy)
        {
            rigidbody.velocity = TargetVelocity;
        }
        else
        {
            Vector2 force = TargetVelocity * Force;
            force.y = 0;
            rigidbody.AddForce(force);
        }
        Vector2 temp = rigidbody.velocity;
        temp.y = 0;
        return temp.normalized;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Slave = false;
        }
    }
}
