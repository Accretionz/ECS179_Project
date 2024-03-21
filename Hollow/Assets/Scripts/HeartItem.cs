using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGain : MonoBehaviour
{
    private PlayerHealthController healthController;

    private void Awake()
    {
        healthController = GameObject.Find("HealthBar").GetComponent<PlayerHealthController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Add one herat
            healthController.AddHeart();
            Destroy(gameObject);
        }
    }
}
