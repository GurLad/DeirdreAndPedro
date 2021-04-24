using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public List<GameObject> ToGenerate;
    public Vector2 GenerateRange;
    public float Offset;
    public bool GenerateOnStart;
    public bool Reverse;
    private float nextGenerated;
    private void Start()
    {
        if (Reverse)
        {
            Offset *= -1;
            GenerateRange *= -1;
        }
        if (GenerateOnStart)
        {
            while(CanGenerate())
            {
                Generate();
            }
        }
        else
        {
            nextGenerated += Offset;
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
        return nextGenerated * (Reverse ? -1 : 1) <= (Offset + transform.position.y) * (Reverse ? -1 : 1);
    }
    private void Generate()
    {
        GameObject generated = Instantiate(ToGenerate[Random.Range(0, ToGenerate.Count)]);
        generated.transform.position = new Vector3(0, nextGenerated, generated.transform.position.z);
        generated.SetActive(true);
        nextGenerated += Random.Range(GenerateRange.x, GenerateRange.y);
    }
}
