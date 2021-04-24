using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float Smooth;
    public Transform ToFollow;
    public Vector3 Offset;
    private void FixedUpdate()
    {
        Vector3 Target = new Vector3(transform.position.x, 0, transform.position.z);
        Target.y = Mathf.Lerp(transform.position.y, ToFollow.transform.position.y + Offset.y, Smooth);
        transform.position = Target;
    }
    [ContextMenu("Find offset")]
    public void FindOffset()
    {
        Offset = transform.position - ToFollow.position;
    }
}
