using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Attack attack;

    static public bool grounded;
    
    public Transform playerTransform;
    public float speed;
    public float jumpHeight;
    public Collider2D groundCollider;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    public static Movement Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attack = GetComponent<Attack>();
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

        if (grounded && Input.GetKeyDown(KeyCode.Z))
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
            playerTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (x == -1)
        {
            playerTransform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void Death()
    {
        playerTransform.position = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        attack.changeDrunk(1f);
    }
}
