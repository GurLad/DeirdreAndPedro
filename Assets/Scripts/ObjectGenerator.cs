using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public List<GameObject> ToGenerate;
    public Vector2 GenerateRange;
    public float Offset;
    public bool GenerateOnStart;
    private float NextGenerated;
    private void Start()
    {
        if (GenerateOnStart)
        {
            while(CanGenerate())
            {
                Generate();
            }
        }
        else
        {
            NextGenerated += Offset;
        }
    }
    private void Update()
    {
        if (CanGenerate())
        {
            Generate();
        }
    }
    private bool CanGenerate()
    {
        return NextGenerated <= Offset + transform.position.y;
    }
    private void Generate()
    {
        GameObject generated = Instantiate(ToGenerate[Random.Range(0, ToGenerate.Count)]);
        generated.transform.position = new Vector3(0, NextGenerated, generated.transform.position.z);
        generated.SetActive(true);
        NextGenerated += Random.Range(GenerateRange.x, GenerateRange.y);
    }
}
