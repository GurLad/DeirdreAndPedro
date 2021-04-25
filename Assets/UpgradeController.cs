using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public PlayerController Player;
    public string InternalName;
    [Header("Health Upgrades")]
    public Sprite[] Containers;
    public SpriteRenderer ContainerObject;
    [Header("Brakes Upgrade")]
    public GameObject BrakesUI;
    [Header("Shield Upgrades")]
    public ShieldController Shield; // TBA: Replace with code
    private void Start()
    {
        PlayerPrefs.SetInt("Shield" + InternalName, 2);
        // Health
        int health = PlayerPrefs.GetInt("Health" + InternalName);
        ContainerObject.sprite = Containers[health];
        Player.Health += health;
        // Brakes
        if (PlayerPrefs.GetInt("Brakes") == 1)
        {
            Player.CanBrake = true;
        }
        else
        {
            Player.BrakesObject.gameObject.SetActive(false);
            BrakesUI.SetActive(false);
        }
        // Shield
        int shieldHP = PlayerPrefs.GetInt("Shield" + InternalName);
        if (shieldHP > 0)
        {
            Shield.Init(shieldHP);
        }
        else
        {
            Destroy(Shield);
        }
    }
}
