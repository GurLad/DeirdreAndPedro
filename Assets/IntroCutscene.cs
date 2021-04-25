using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutscene : MonoBehaviour
{
    public Image[] Parts;
    public float Speed;
    private float count;
    private int currentID;
    private bool firstFrame = true;
    private void Start()
    {
        Parts[0].gameObject.SetActive(true);
    }
    private void Update()
    {
        if (firstFrame)
        {
            firstFrame = false;
            return;
        }
        count += Time.deltaTime * Speed;
        Color temp = Parts[currentID].color;
        temp.a = count;
        Parts[currentID].color = temp;
        if (count >= 1)
        {
            count--;
            temp.a = 1;
            Parts[currentID++].color = temp;
            if (currentID >= Parts.Length)
            {
                Destroy(this);
            }
            else
            {
                Parts[currentID].gameObject.SetActive(true);
            }
        }
    }
}
