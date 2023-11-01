using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject settings;
    GameObject audioS;

    private void Awake()
    {
        audioS = GameObject.FindGameObjectWithTag("Audio");
    }
    public void PasueGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        audioS.SetActive(false);
    }

    public void Home()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        Time.timeScale = 1;
    }

    public void Settings()
    {
        settings.SetActive(true);
        pauseMenu.SetActive(false);
    }
    
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        audioS.SetActive(true);

    }

    public void Replay()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        audioS.SetActive(true);
    }

    public void Close()
    {
        Time.timeScale = 1;
        audioS.SetActive(true);
    }
}
