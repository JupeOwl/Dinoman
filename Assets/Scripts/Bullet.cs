using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;
    private Animator animator;
    private bool move = true;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Invoke("enableCollider", 0.08f);

        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            bulletRb.velocity = transform.right * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionTag = collision.gameObject.tag;

        if (collisionTag == "Player")
            return;

        animator.SetTrigger("splats");
        move = false;

        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<CircleCollider2D>().enabled = false;
        Destroy(gameObject, 0.3f);
    }

    private void enableCollider()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
