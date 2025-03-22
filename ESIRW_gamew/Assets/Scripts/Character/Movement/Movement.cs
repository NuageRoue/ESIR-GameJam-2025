using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    CharacterController characterController; // for now, created by the character (in Awake).
                                             // but later, the game manager will assign it on loading the main scene

    [Header("jump")]
    Rigidbody2D rb;
    [SerializeField] float jumpForce;
    [SerializeField] bool grounded;
    [SerializeField] bool isJumping; // check wether or not the jump key is pressed to add a 
    [SerializeField] float jumpTimerValue;
    [SerializeField] float jumpTimer;

    [Header("Ground Check Settings")]
    public LayerMask groundLayer; // Assign in the inspector
    public float groundCheckDistance = 0.1f;
    public Vector2 boxSize;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxSize = GetComponent<Collider2D>().bounds.size;
        isJumping = false;

        characterController = new CharacterController();
        characterController.MainActionMap.Enable();
        //characterController.MainActionMap.Jump.performed += ContextLogger;
    }

    private void Update()
    {
        MoveAround(characterController.MainActionMap.MovingAround.ReadValue<float>());

        CheckIfGrounded();
        Jump();

    }
    void CheckIfGrounded()
    {
        grounded = Physics2D.BoxCast(transform.position, boxSize, 0f, Vector2.down, groundCheckDistance, groundLayer);
        if (grounded && !isJumping)
        {
            rb.gravityScale = 1f;
        }
    }
    public void Jump()
    {
        
        if (characterController.MainActionMap.Jump.ReadValue<float>() == 1)
        {
            if (grounded)
            {
                isJumping = true;
                jumpTimer = jumpTimerValue;
            }
            
        }
        else
        {
            isJumping = false;
        }
        if (isJumping)
        {
            rb.gravityScale = 0f;
            transform.position += new Vector3(0, jumpForce * Time.deltaTime, 0);
            jumpTimer -= Time.deltaTime;
        }
        if (!isJumping || jumpTimer <= 0)
        {
            jumpTimer = 0;
            isJumping = false;
            rb.gravityScale = 3f;
        }

    }
    public void MoveAround(float direction)
    {
        if (direction != 0)
            Move(direction);
    }
    public void Move(float direction)
    {
        transform.position += new Vector3(direction * speed * Time.deltaTime, 0);
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
