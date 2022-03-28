using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private bool grounded;
    
    public Transform playerTransform;
    public float speed;
    public float jumpHeight;
    public Collider2D groundCollider;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();

        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.17f, groundLayer);

        if (grounded)
        {
            animator.SetBool("falls", true);
            animator.SetBool("jumps", false);
        } else
        {
            animator.SetBool("falls", false);
        }

        if (grounded && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpHeight);
            animator.SetBool("jumps", true);
        }

        if (playerTransform.position.y < -8) 
        {
            Death();
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        if (x != 0)
        {
            animator.SetBool("move", true);
        } else if (grounded)
        {
            animator.SetBool("move", false);
        }

        if (x == 1)
        {
            playerTransform.localScale = new Vector3(1, 1, 1);
        }
        else if (x == -1)
        {
            playerTransform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Death()
    {
        playerTransform.position = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
