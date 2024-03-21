using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject heart;
    private bool canOpen;
    private bool isOpened;
    private Animator anim;
    public float delayTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Once the player touched the chest, open the chest
            if (canOpen && !isOpened)
            {
                anim.SetTrigger("Opening");
                isOpened = true;
                Invoke("GenHeart", delayTime);
            }
        }
    }

    void GenHeart()
    {
        Instantiate(heart, transform.position, Quaternion.identity);
    }

    // When player touch the chest
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = true;
        }
        */
        if (collision.gameObject.tag == "Player")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*
        if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = false;
        }
        */
        if (collision.gameObject.tag == "Player")
        {
            canOpen = false;
        }
    }
}
