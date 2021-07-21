using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character;

    private Vector3 velocity;

    private bool isGrounded;

    public float moveSpeed = 10f;

    public float jumpHeight = 5f;

    public float gravity = -9.81f;

    public float gravityScale = 2f;

    public Transform groundCheck;
    public float groundDistance =0.4f;
    public LayerMask groundMask;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;

        character.Move(moveDirection * moveSpeed * Time.deltaTime);


        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight*-2*gravity)*Time.deltaTime;
        }

        velocity.y += 0.5f*gravity * Time.deltaTime * Time.deltaTime*gravityScale;
        character.Move(velocity);
    }
}
