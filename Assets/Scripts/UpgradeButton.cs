using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int Cost;
    [TextArea]
    public string Description;
    public string PlayerPrefName;
    public string PlayerInternalName;
    public string UniqueID;
    public Color BoughtColor;
    public AudioClip BoughtSFX;
    private Text text;
    private Button button;
    private Image image;
    private bool Bought
    {
        get
        {
            return PlayerPrefs.GetInt(UniqueID) == 1;
        }
        set
        {
            PlayerPrefs.SetInt(UniqueID, value ? 1 : 0);
        }
    }
    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        text.text = Cost.ToString();
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        if (Bought)
        {
            image.color = BoughtColor;
        }
    }
    public void UpdateCanBuy()
    {
        button.interactable = PlayerPrefs.GetInt("Points") >= Cost && !Bought;
    }
    public void Buy()
    {
        PlayerPrefs.SetInt("Points", PlayerPrefs.GetInt("Points") - Cost);
        PlayerPrefs.SetInt(PlayerPrefName + PlayerInternalName, PlayerPrefs.GetInt(PlayerPrefName + PlayerInternalName) + 1);
        Bought = true;
        image.color = BoughtColor;
        SoundController.PlaySound(BoughtSFX);
        UpgradeMenu.Current.PostBuy();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        UpgradeMenu.Current.ShowDescription(Description);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        UpgradeMenu.Current.ShowDescription("");
    }
}
