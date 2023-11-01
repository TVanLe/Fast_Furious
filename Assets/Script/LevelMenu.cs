using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        int unlocked = PlayerPrefs.GetInt("Unlocked", 1);

        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for(int i = 0; i < Mathf.Min(unlocked , buttons.Length); i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void OpenLevel(int name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
