using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakesUI : MonoBehaviour
{
    public PlayerController Player;
    public RectTransform Meter;
    private float baseSize;
    private void Start()
    {
        baseSize = Meter.sizeDelta.y;
    }
    private void Update()
    {
        Meter.sizeDelta = new Vector2(Meter.sizeDelta.x, baseSize * Player.BrakesValue);
    }
}
