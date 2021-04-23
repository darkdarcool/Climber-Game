using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    //player speed 
    public float playerSpeed;

    //player rigidbody component reference
    public Rigidbody rb;

    //ground variables
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    bool isGrounded;

    //jump height
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //setting our bool based on if we are touching the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        MoveInput();
        Jump();
    }

    private void MoveInput()
    {
        //Getting our inputs from WASD from Unity's Input system
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        //Applying our WASD input into a vector3
        Vector3 playerMovement = new Vector3(hori, 0, vert) * playerSpeed * Time.deltaTime;

        //moving our player using our newly created vector3
        transform.Translate(playerMovement, Space.Self);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }
}

