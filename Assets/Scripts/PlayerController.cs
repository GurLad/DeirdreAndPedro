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
    public float KnockbackForce;
    public float RecoverSpeed;
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
            OtherPlayer._slave = !Slave;
        }
    }
    private Rigidbody2D rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
        Slave = _slave;
    }
    private void FixedUpdate()
    {
        if (!Slave)
        {
            Move(new Vector2(Input.GetAxis("Horizontal"), YSpeed));
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
            Vector3 target = OtherPlayer.transform.position;
            target.y *= -1;
            transform.position = target;
        }
    }
    private void Move(Vector2 target)
    {
        float tempY = rigidbody.velocity.y;
        Vector2 workingVelocity = rigidbody.velocity;
        // X stuff
        if (workingVelocity.x > Speed)
        {
            workingVelocity.x = Speed;
        }
        Vector2 TargetVelocity = new Vector2(target.x, 0) * Speed;
        if (TargetVelocity.x == 0)
        {
            if (Mathf.Abs(workingVelocity.x) <= Accuracy)
            {
                workingVelocity.x = 0;
            }
            else
            {
                Vector2 force = Vector2.zero;
                force.x = -Mathf.Sign(workingVelocity.x) * ResetForce;
                rigidbody.AddForce(force);
            }
        }
        else
        {
            TargetVelocity.y = workingVelocity.y;
            if ((workingVelocity - TargetVelocity).magnitude <= Accuracy)
            {
                workingVelocity = TargetVelocity;
            }
            else
            {
                Vector2 force = TargetVelocity * Force;
                force.y = 0;
                rigidbody.AddForce(force);
            }
        }
        // Y stuff
        if (Mathf.Abs(tempY - target.y) <= Accuracy)
        {
            workingVelocity.y = target.y;
        }
        else
        {
            workingVelocity.y = tempY + target.y * Time.deltaTime * RecoverSpeed;
        }
        // Finish
        //Debug.Log(workingVelocity);
        rigidbody.velocity = workingVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Slave = false;
            rigidbody.velocity = new Vector2(0, -Mathf.Sign(YSpeed) * KnockbackForce);
            collision.gameObject.GetComponent<Enemy>().AfterCollision();
        }
    }
}
