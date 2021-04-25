using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressEscape : MonoBehaviour
{
    public GameObject PauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu != null)
            {
                if (!PauseMenu.activeSelf)
                {
                    PauseMenu.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    PauseMenu.SetActive(false);
                    Time.timeScale = 1;
                }
            }
            else
            {
                SceneLoader.LoadScene("MainMenu");
            }
        }
    }
}
