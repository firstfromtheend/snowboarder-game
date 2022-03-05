using System.Collections;
using UnityEngine;

public class DustTrail : MonoBehaviour
{

    [SerializeField] ParticleSystem snowTrail;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            snowTrail.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            snowTrail.Stop();
        }
    }
}