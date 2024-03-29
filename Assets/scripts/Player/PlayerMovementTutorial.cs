using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovementTutorial : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;
    public float airDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    [SerializeField] GravityController gravityController;
    [SerializeField] float UpDownSpeed;
    public bool canControlSpeed = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Physics.gravity = new Vector3(0, -gravityController.gravityForce, 0);

        readyToJump = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, transform.TransformVector(Vector3.down), playerHeight * 0.5f + 0.3f, whatIsGround);
        if (gravityController.canCheckIfGround && grounded)
        {
            gravityController.canChangeGravity = true;
        }
        if (grounded)
        {
            canControlSpeed = true;
        }

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = airDrag;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        Debug.Log(verticalInput);
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //Debug.Log(moveDirection);
        // on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }         
        // in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        //limit velocity if needed
        if (flatVel.magnitude > moveSpeed && canControlSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;

            if (Physics.gravity == new Vector3(-gravityController.gravityForce, 0, 0) || Physics.gravity == new Vector3(gravityController.gravityForce, 0, 0))
            {
                rb.velocity = new Vector3(rb.velocity.x, limitedVel.y, limitedVel.z);
            }
            else if (Physics.gravity == new Vector3(0, -gravityController.gravityForce, 0) || Physics.gravity == new Vector3(0, gravityController.gravityForce, 0))
            {
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
            else if (Physics.gravity == new Vector3(0, 0, -gravityController.gravityForce) || Physics.gravity == new Vector3(0, 0, gravityController.gravityForce))
            {
                rb.velocity = new Vector3(limitedVel.x, limitedVel.y, rb.velocity.z);
            }
        }
    }

    private void Jump()
    {
        // reset y velocity
        //rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}