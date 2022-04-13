using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        animator.SetFloat("jumpVelocity", rb.velocity.y);

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
