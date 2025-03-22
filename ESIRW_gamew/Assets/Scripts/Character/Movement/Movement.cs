using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float movementSpeed_WhileJumping;

    bool isMoving = false;
    [SerializeField] float movementSpeed_Default;
    [SerializeField] float slowdownTimerValue;
    float slowdownTimer;
    CharacterController characterController; // for now, created by the character (in Awake).
                                             // but later, the game manager will assign it on loading the main scene

    [Header("jump")]
    Rigidbody2D rb;
    [SerializeField] float jumpMax;
    [SerializeField] float jumpMin;
    [SerializeField] float jumpForce;
    [SerializeField] float minJumpTimer;
    [SerializeField] bool grounded;
    [SerializeField] bool isJumping; // check wether or not the jump key is pressed to add a 
    [SerializeField] float jumpTimerValue;
    [SerializeField] float jumpTimer;

    [Header("Ground Check Settings")]
    public LayerMask groundLayer; // Assign in the inspector
    public float groundCheckDistance = 0.1f;
    public Vector2 boxSize;
    [SerializeField] float boxSizeRatio;
    private void Awake()
    {
        movementSpeed = movementSpeed_Default;
        rb = GetComponent<Rigidbody2D>();
        boxSize = GetComponent<Collider2D>().bounds.size;
        isJumping = false;
        jumpForce = jumpMax / jumpTimerValue;
        minJumpTimer = jumpTimerValue - (jumpMin / jumpForce);
        characterController = new CharacterController();
        characterController.MainActionMap.Enable();
        characterController.MainActionMap.Jump.started += StartJump;
    }

    private void Update()
    {
        MoveAround(characterController.MainActionMap.MovingAround.ReadValue<float>());

        CheckIfGrounded();
        Jump();
    }
    void CheckIfGrounded()
    {
        float distance;
        if (isJumping && !grounded)
            distance = groundCheckDistance * 2;
        else
            distance = groundCheckDistance;
        grounded = Physics2D.BoxCast(transform.position, new Vector2(boxSize.x * boxSizeRatio, boxSize.y), 0f, Vector2.down, distance, groundLayer);
        if (grounded && !isJumping)
        {
            rb.gravityScale = 1f;
        }
    }

    public void StartJump(InputAction.CallbackContext context)
    {
        if (grounded)
        {
            isJumping = true;
            jumpTimer = jumpTimerValue;
            if (isMoving)
                movementSpeed = movementSpeed_WhileJumping;
        }
    }
    public void Jump()
    {
        if (characterController.MainActionMap.Jump.ReadValue<float>() != 1 || Physics2D.BoxCast(transform.position, new Vector2(boxSize.x * boxSizeRatio, boxSize.y), 0f, Vector2.up, jumpForce * Time.deltaTime, groundLayer))
        {
            isJumping = false;
        }


        if ((isJumping || jumpTimer > minJumpTimer) )
        {
            rb.gravityScale = 0f;
            transform.position += new Vector3(0, jumpForce * Time.deltaTime, 0);
            jumpTimer -= Time.deltaTime;
        }
        if ((!isJumping && jumpTimer <= minJumpTimer) || jumpTimer <= 0 || Physics2D.BoxCast(transform.position, new Vector2(boxSize.x*boxSizeRatio, boxSize.y), 0f, Vector2.up, jumpForce * Time.deltaTime, groundLayer))
        {
            jumpTimer = 0;
            isJumping = false;
            rb.gravityScale = 3f;
        }

    }

    

     
    public void MoveAround(float direction)
    {
        if (direction != 0 && !Physics2D.BoxCast(transform.position, new Vector2(boxSize.x, boxSize.y * boxSizeRatio), 0f, Vector2.right * direction, direction * movementSpeed * Time.deltaTime, groundLayer))
        {
            isMoving = true;
            Move(direction);
            slowdownTimer = 0;
        }
        else if (direction != 0 && Physics2D.BoxCast(transform.position, new Vector2(boxSize.x, boxSize.y * boxSizeRatio), 0f, Vector2.right * direction, direction * movementSpeed * Time.deltaTime, groundLayer))
        {
            Debug.Log("there");
            isMoving = false;
            if (!isJumping)
                movementSpeed = movementSpeed_Default;
        }
        else
        {
            if (slowdownTimer >= slowdownTimerValue)
            {
                Debug.Log("here");
                isMoving = false;
                if (!isJumping)
                    movementSpeed = movementSpeed_Default;
            }
            if (isMoving)
                slowdownTimer += Time.deltaTime;
        }
    }
    public void Move(float direction)
    {
        transform.position += new Vector3(direction * movementSpeed * Time.deltaTime, 0);
        transform.localScale = new Vector3(
            Mathf.Abs(transform.localScale.x) * Mathf.Sign(direction),
            transform.localScale.y,
            transform.localScale.z
            );
    }

    void ContextLogger(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }
}
