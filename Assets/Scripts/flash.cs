using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    private RectTransform size;
    private float lastTime;
    private int lastWidth;

    // Start is called before the first frame update
    void Start()
    {
        size = GetComponent<RectTransform>();

        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastTime + 1f)
        {
            if(lastWidth == 1)
            {
                size.sizeDelta = new Vector2(18, 30);
                lastWidth = 18;
            } else
            {
                size.sizeDelta = new Vector2(1, 30);
                lastWidth = 1;
            }

            lastTime = Time.time;
        }
    }
}
