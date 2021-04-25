using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Horizontal movement vars")]
    public float Force;
    public float ResetForce;
    public float Accuracy;
    [Header("Stats")]
    public float XSpeed;
    public float YSpeed;
    public float Health = 3;
    public float BrakesUseRate = 1.5f;
    public float BrakesRechargeRate = 0.75f;
    [Header("Brakes")]
    public SpriteRenderer BrakesObject;
    public Sprite[] BrakesSprites;
    [Header("Stuff")]
    public float KnockbackForce;
    public float RecoverSpeed;
    public PlayerController OtherPlayer;
    [HideInInspector]
    public float BrakesValue = 1;
    [HideInInspector]
    public bool CanBrake;
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
    public int Distance
    {
        get
        {
            return (int)Mathf.Abs(Mathf.Round(transform.position.y));
        }
    }
    private Rigidbody2D rigidbody;
    private bool holdingBrakes;
    private float baseYSpeed;
    private float trueYSpeed
    {
        get
        {
            return baseYSpeed * (1 + Distance / 150f);
        }
    }
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 60;
        Slave = _slave;
        baseYSpeed = YSpeed;
        //rigidbody.velocity = new Vector2(0, YSpeed);
    }
    private void FixedUpdate()
    {
        if (!Slave)
        {
            if (CanBrake)
            {
                if (Input.GetAxis("Vertical") < 0 && (BrakesValue >= 0.1f || (holdingBrakes && BrakesValue > 0)))
                {
                    OtherPlayer.BrakesObject.sprite = BrakesObject.sprite = BrakesSprites[1];
                    YSpeed = 0.25f * Mathf.Sign(baseYSpeed);
                    BrakesValue -= BrakesUseRate * Time.deltaTime;
                    if (BrakesValue < 0)
                    {
                        BrakesValue = 0;
                    }
                    holdingBrakes = true;
                }
                else
                {
                    OtherPlayer.BrakesObject.sprite = BrakesObject.sprite = BrakesSprites[0];
                    YSpeed = trueYSpeed;
                    BrakesValue += BrakesRechargeRate * Time.deltaTime;
                    if (BrakesValue > 1)
                    {
                        BrakesValue = 1;
                    }
                    holdingBrakes = false;
                }
            }
            else
            {
                YSpeed = trueYSpeed;
            }
            OtherPlayer.BrakesValue = BrakesValue;
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
        if (workingVelocity.x > XSpeed)
        {
            workingVelocity.x = XSpeed;
        }
        Vector2 TargetVelocity = new Vector2(target.x, 0) * XSpeed;
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
            Vector2 force = new Vector2(0, -Mathf.Sign(tempY - target.y) * RecoverSpeed);
            rigidbody.AddForce(force);
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
            Health--;
            if (Health <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
            }
        }
    }
}
