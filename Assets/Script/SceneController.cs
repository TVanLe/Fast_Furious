using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    MovementController movementController;
    public static SceneController instance;
    public Animator anim;

    private void Awake()
    {
        movementController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        StartCoroutine(LoadSceneAnimation(1f));
        
    }
    
    IEnumerator LoadSceneAnimation(float duration)
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(duration);

        int nextBuildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextBuildIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadSceneAsync(nextBuildIndex);
        
        anim.SetTrigger("Start");
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

}
