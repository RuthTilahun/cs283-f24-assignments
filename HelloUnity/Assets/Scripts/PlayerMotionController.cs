using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turningSpeed = 100.0f;
    private Animator myAnimator;
    private bool isMoving;

    private CharacterController controller;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;
    private Vector3 velocity;

   

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        myAnimator = gameObject.GetComponent<Animator>();
        isMoving = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if(groundedPlayer && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * horizontalInput * turningSpeed * Time.deltaTime);
        Vector3 move = transform.forward * verticalInput;
        controller.Move(move * Time.deltaTime * moveSpeed);

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        isMoving = Mathf.Abs(verticalInput) > 0.1f;
        myAnimator.SetBool("isMoving", isMoving);

    }
}
