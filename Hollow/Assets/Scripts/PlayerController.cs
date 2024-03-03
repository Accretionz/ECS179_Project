using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 5.0f;

    // private IPlayerCommand right;
    // private IPlayerCommand left;
    // private IPlayerCommand up;
    // private IPlayerCommand down;
    void Start()
    {
        // this.right = ScriptableObject.CreateInstance<MovePlayerRight>();
        // this.left = ScriptableObject.CreateInstance<MovePlayerLeft>();
        // this.up = ScriptableObject.CreateInstance<MovePlayerUp>();
        // this.down = ScriptableObject.CreateInstance<MovePlayerDown>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetAxis("Horizontal") > 0.01)
        // {
        //     this.right.Execute(this.gameObject);
        // }
        // if (Input.GetAxis("Horizontal") < -0.01)
        // {
        //     this.left.Execute(this.gameObject);
        // }
        // if (Input.GetAxis("Vertical") > 0.01)
        // {
        //     this.up.Execute(this.gameObject);
        // }
        // if (Input.GetAxis("Vertical") < -0.01)
        // {
        //     this.down.Execute(this.gameObject);
        // }
        if (Input.GetAxis("Horizontal") > 0.01)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetAxis("Horizontal") < -0.01)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        var movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        gameObject.transform.Translate(movementDirection * Time.deltaTime * speed);
    }
}
