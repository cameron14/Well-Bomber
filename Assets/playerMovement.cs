using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    AudioSource footsteps;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        if (Input.GetButtonDown("Horizontal"))
        {
            GetComponent<AudioSource> ().Play ();

        }

        if (Input.GetButtonUp("Horizontal"))
        {
            GetComponent<AudioSource> ().Pause ();
        }


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    // Player movement
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
