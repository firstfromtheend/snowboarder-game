using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Snowboarder snowboarderControllGroup;
    private SurfaceEffector2D surfaceEffector2D;
    private Rigidbody2D playerRB2d;

    [SerializeField] float torque = 20f;

    [SerializeField] float boostSpeed = 40f;
    [SerializeField] float normalSpeed = 20f;

    private bool canMove = true;

    private void Awake()
    {
        snowboarderControllGroup = new Snowboarder();
        playerRB2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

        //Boost
        snowboarderControllGroup.Player.Boost.performed += ctx => AddBoost();
        snowboarderControllGroup.Player.Boost.canceled += ctx =>
        {
            if (surfaceEffector2D != null)
            {
                surfaceEffector2D.speed = normalSpeed;
            }
        };

        //Torque
        snowboarderControllGroup.Player.Torque.performed += ctx => PlayerTorque();
    }

    private void OnEnable()
    {
        snowboarderControllGroup.Player.Enable();
    }

    private void OnDisable()
    {
        snowboarderControllGroup.Player.Disable();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            PlayerTorque();
        }
    }
    private void PlayerTorque()
    {
        playerRB2d.AddTorque(torque * snowboarderControllGroup.Player.Torque.ReadValue<float>());
    }

    private void AddBoost()
    {
        if (canMove && surfaceEffector2D != null)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    public bool GetCanMoove()
    {
        return canMove;
    }
}
