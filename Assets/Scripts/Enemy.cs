using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public GameObject drop;

    public float speed;

    protected Vector3 currentTarget;

    private void Start()
    {
        currentTarget = pointA.position;
    }

    void Update()
    {
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collisionTag = collision.gameObject.tag;

        if (collisionTag == "Bullet")
        {
            Instantiate(drop, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}