using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB2d;
    private SurfaceEffector2D surafaceEffector2d;

    [SerializeField] float playerTorqueAmount;
    [SerializeField] float playerTorqueAmountNegative;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float normalSpeed = 20f;

    private void Awake()
    {
        surafaceEffector2d = FindObjectOfType<SurfaceEffector2D>();
        playerRB2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surafaceEffector2d.speed = boostSpeed;
        }
        else
        {
            surafaceEffector2d.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRB2d.AddTorque(playerTorqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRB2d.AddTorque(-playerTorqueAmountNegative);
        }
    }
}
