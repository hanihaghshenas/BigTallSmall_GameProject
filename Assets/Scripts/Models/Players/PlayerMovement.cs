using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    PhotonView View;
    // bool crouch = false;

    // Update is called once per frame
    private void Start()
    {
        View = GetComponent<PhotonView>();
    }
    void Update () {

        if (View.IsMine)
        {

            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Math.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
        }

        // if (Input.GetButtonDown("Crouch"))
        // {
            //
        //     crouch = true;
        // } else if (Input.GetButtonUp("Crouch"))
        // {
        //     crouch = false;
        // }

    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }
    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}