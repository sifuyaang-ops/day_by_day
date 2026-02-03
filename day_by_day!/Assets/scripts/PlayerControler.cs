using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{

    public Rigidbody2D rb;
    public PlayerInput pi;

    Vector2 moveInput;
    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask ground;
    public float groundRadius = .5f;
    private bool isGround;
    private int dir = 1;
    private void Update()
    {
        isGround = IsOnGround();
    }


    private void FixedUpdate()
    {
        Flip();
        MovePlayer();
    }

    bool IsOnGround()
    {

        return Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
    }
    void Flip()
    {
        if (moveInput.x > .1f)
        {
            dir = 1;
        }else if(moveInput.x < -.1f)
        {
            dir = -1;
        }
        transform.localScale = new Vector3(dir, 1, 1);

    }

    void MovePlayer()
    {

        float move = moveInput.x * speed;

        rb.linearVelocity= new Vector2(move,rb.linearVelocity.y);
    }

    void OnMove(InputValue value)
    {
        moveInput=value.Get<Vector2>();

    }
    void OnJump(InputValue Value)
    {
        if (Value. isPressed &&isGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position,groundRadius);
    }
}
