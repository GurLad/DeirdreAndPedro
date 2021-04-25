using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public static UpgradeMenu Current;
    [HideInInspector]
    public List<UpgradeButton> UpgradeButtons;
    public Text PointsText;
    public Text HighScoreText;
    public Text DescriptionText;
    private void Awake()
    {
        Current = this;
    }
    private void Start()
    {
        UpgradeButtons = new List<UpgradeButton>(GetComponentsInChildren<UpgradeButton>());
        PostBuy();
    }
    public void PostBuy()
    {
        UpgradeButtons.ForEach(a => a.UpdateCanBuy());
        PointsText.text = "Points: " + PlayerPrefs.GetInt("Points");
        HighScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
    public void ShowDescription(string s)
    {
        DescriptionText.text = s;
    }
}
