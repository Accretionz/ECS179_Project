using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeFromChest1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When player touch the teleport, resume to sample scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Teleport" || collision.gameObject.tag == "Teleport2")
        {
            Time.timeScale = 1f;
            Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
