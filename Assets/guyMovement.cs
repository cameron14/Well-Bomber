using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guyMovement : MonoBehaviour
{
    AudioSource footsteps;  // footsteps sound effect
    public float speed; // speed that the character can move
    public Rigidbody2D playerRigidBody; // the character rigidbody
    public float jumpHeight; // how high the character can jump


    // Update is called once per frame (check for user input for movement)
    void Update()
    {
        // if the player presses the horizontal input keys, move the character in the correct direction.
        float horizontal = Input.GetAxis ("Horizontal");
        transform.Translate(horizontal * Time.deltaTime * speed, 0f, 0f);

        // if horizontal key inputs are detected play the footsteps sound effect
        if (Input.GetButtonDown("Horizontal"))
        {
            GetComponent<AudioSource> ().Play ();

        }
        // if horizontal key inputs are not detected, do not play the footsteps sound effect
        if (Input.GetButtonUp("Horizontal"))
        {
            GetComponent<AudioSource> ().Pause ();
        }

        // if the player presses the space bar, make the character jump
        if(Input.GetButtonDown ("Jump") && playerRigidBody.velocity.y < 1f && playerRigidBody.velocity.y > -1f)
        {
            playerRigidBody.AddRelativeForce(new Vector2(0f, jumpHeight));
        }
    }
}
