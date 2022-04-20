using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public static Attack Instance { get; set; }
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

    private Animator animator;
    private float lastTime;

    public Image Drunk;
    public float kickCooldown;
    public float fireCooldown;
    public GameObject fireball;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Drunk.fillMethod = Image.FillMethod.Vertical;
        Drunk.fillAmount = 1f;

        Drunk.type = Image.Type.Filled;
        lastTime = Time.time - 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Movement.grounded && Input.GetKeyDown(KeyCode.X))
        {
            if (Time.time > lastTime + kickCooldown)
            {
                animator.SetTrigger("attack");
                Movement.Instance.jumpHeight += 0.5f;
                
                lastTime = Time.time;

                Invoke("endKarate", 1f);
            }   
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Time.time > lastTime + fireCooldown)
            {
                if (Drunk.fillAmount > 0)
                {
                    animator.SetTrigger("Shoots");

                    Instantiate(fireball, transform.position, transform.rotation);

                    Drunk.fillAmount -= 0.03f;
                }

                lastTime = Time.time;            
            }
        }
    }

    public void changeDrunk(float amount)
    {
        Drunk.fillAmount = amount;
    }

    void endKarate()
    {
        Movement.Instance.jumpHeight -= 0.5f;
    }
}
