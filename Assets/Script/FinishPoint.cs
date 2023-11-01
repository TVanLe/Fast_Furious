using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Next Level
            UpdateLevel();
            SceneController.instance.NextLevel(); 
        }
    }

    public void UpdateLevel()
    {
        int nowScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nowScene >= PlayerPrefs.GetInt("Unlocked" , 1))
        {
            PlayerPrefs.SetInt("Unlocked", nowScene);
            PlayerPrefs.Save();
        }
    }
}
