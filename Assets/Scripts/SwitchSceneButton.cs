using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneButton : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneLoader.LoadScene(name);
    }
}
