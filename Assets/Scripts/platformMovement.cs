using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{
    public float Speed = 5f;
    public float Distance = 20f;
    public bool PlatformTypeUP = false;
    Vector2 StartPos;
    
    private void Start()
    {
        StartPos = transform.position;
    }
    
    private void Update()
    {
        if (!PlatformTypeUP)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2((StartPos.x + Distance), transform.position.y), Speed * Time.deltaTime);
            
            if (Distance < 0)
            {
                if (transform.position.x <= (StartPos.x + Distance))
                {
                    Distance = -1;
                }
            }
            
            else
            {
                if (transform.position.x >= (StartPos.x + Distance))
                {
                    Distance = -1;
                }
            }
        }
        
        else
        {
            
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, (StartPos.y + Distance)), Speed * Time.deltaTime);
            if (Distance < 0)
            {
                if (transform.position.y <= (StartPos.y + Distance))
                {
                    Distance = -1;
                }
            }
            
            else
            {
                if (transform.position.y >= (StartPos.y + Distance))
                {
                    Distance = -1;
                }
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.transform.SetParent(gameObject.transform, true);
    }
    
    private void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.transform.parent = null;
    }
}