using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack.Instance.Drunk.fillAmount += 0.1f;
            Destroy(gameObject);
        }
    }
}
