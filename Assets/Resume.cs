using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject PauseMenu;
    public void Click()
    {
        Time.timeScale = 1;
        PauseMenu.gameObject.SetActive(false);
    }
}
