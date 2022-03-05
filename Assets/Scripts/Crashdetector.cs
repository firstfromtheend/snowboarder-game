using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Crashdetector : MonoBehaviour
    {
        PlayerController playerController;

        [SerializeField] float timeToLoadNewScene = 1.5f;
        [SerializeField] ParticleSystem dawnFall;
        [SerializeField] AudioClip crashSFX;

        private void Awake()
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Snow"))
            {
                if (playerController.GetCanMoove())
                {
                    dawnFall.Play();
                    GetComponent<AudioSource>().PlayOneShot(crashSFX);
                }
                playerController.DisableControls();
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