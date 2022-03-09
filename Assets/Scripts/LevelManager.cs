using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delayBeforeLoad = 1f;
    private int indexCurrentScene = 0;

    //static LevelManager instance;

    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        gameObject.SetActive(false);
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(instance);
    //    }
    //}

    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoadScene(0, delayBeforeLoad));
        //indexCurrentScene = 0;
    }
    
    public void LoadLevel1()
    {
        StartCoroutine(WaitAndLoadScene(1, delayBeforeLoad));
        //indexCurrentScene = 1;
    }

    public void Restartlevel()
    {
        StartCoroutine(WaitAndLoadScene(indexCurrentScene, delayBeforeLoad));
    }

    public void Quit()
    {
        Debug.Log("quitting");
        Application.Quit();
    }

    IEnumerator WaitAndLoadScene(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
        indexCurrentScene = sceneIndex;
    }
}
