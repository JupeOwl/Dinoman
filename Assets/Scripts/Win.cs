using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject player;
    public GameObject winThing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        winPanel.SetActive(true);
        winThing.GetComponent<Text>().text = Movement.Instance.deaths.ToString();
        
        Destroy(player);
    }
}
