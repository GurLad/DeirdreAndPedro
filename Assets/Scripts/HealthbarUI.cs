using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarUI : MonoBehaviour
{
    public PlayerController Player;
    private RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        rectTransform.sizeDelta = new Vector2(32 * Player.Health, 32);
    }
}
