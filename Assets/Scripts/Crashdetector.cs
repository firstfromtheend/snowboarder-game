using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Crashdetector : MonoBehaviour
    {
        [SerializeField] float timeToLoadNewScene = 1.5f;
        [SerializeField] ParticleSystem dawnFall;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Snow"))
            {
                dawnFall.Play();
                StartCoroutine(ReloadScene());
            }
        }

        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(Mathf.Clamp(timeToLoadNewScene, 0, float.MaxValue));
            SceneManager.LoadScene("Gameplay");
        }
    }
}