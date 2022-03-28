using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;

    private Transform selfTransform;

    private void Start()
    {
        selfTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float yPosition = 0f;
        float xPosition = 0f;

        if (playerTransform.position.y < 0)
        {
            yPosition = 0f;
        } 
        else if (playerTransform.position.y > 7) 
        {
            yPosition = 7f;
        }
        else
        {
            yPosition = playerTransform.position.y;
        }

        if (!(playerTransform.position.x < 0))
        {
            xPosition = playerTransform.position.x;
        }

        selfTransform.position = new Vector3(xPosition, yPosition, -10);
    }
}
