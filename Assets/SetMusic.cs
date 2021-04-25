using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusic : MonoBehaviour
{
    public string Name;
    public bool KeepTimestamp;
    private void Awake()
    {
        CrossfadeMusicPlayer.Instance.Play(Name, KeepTimestamp);
    }
}
