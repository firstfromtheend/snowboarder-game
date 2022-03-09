using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float timeToLoadNewScene = 1.5f;
    [SerializeField] ParticleSystem salute;

    LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            salute.Play();
            GetComponent<AudioSource>().Play();
            //StartCoroutine(ReloadScene());
            levelManager.LoadMainMenu();
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(Mathf.Clamp(timeToLoadNewScene, 0, float.MaxValue));
        SceneManager.LoadScene("Gameplay");
    }
}