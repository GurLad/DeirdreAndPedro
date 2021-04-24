using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUI : MonoBehaviour
{
    public PlayerController Player;
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        int dist = (int)Mathf.Abs(Mathf.Round(Player.transform.position.y));
        text.text = "Dist.: " + dist;
        if (dist > 40)
        {
            CrossfadeMusicPlayer.Instance.Play("Game3");
        }
        else if (dist > 20)
        {
            CrossfadeMusicPlayer.Instance.Play("Game2");
        }
        else
        {
            CrossfadeMusicPlayer.Instance.Play("Game1");
        }
    }
}
