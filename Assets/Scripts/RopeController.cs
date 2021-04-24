using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    private void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (Player1.transform.localPosition.y - Player2.transform.localPosition.y) * (32 / 4), transform.localScale.z);
        transform.position = new Vector3(Player1.transform.position.x, 0, transform.position.z);
    }
}
