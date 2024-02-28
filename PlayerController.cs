using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

// Roughly change the CaptainController template in exercise 1, need more updates
public class CaptainController : MonoBehaviour
{
    //private IPlayerCommand fire1;
    //private IPlayerCommand fire2;
    private IPlayerCommand upward;
    private IPlayerCommand downward;
    private IPlayerCommand right;
    private IPlayerCommand left;

    // spawn items
    [SerializeField]
    private UnityEngine.UI.Text booty;
    private int mushrooms;
    private int skulls;
    private int gems;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.AddComponent<CaptainMotivateCommand>();
        //this.fire1 = gameObject.AddComponent<CaptainMotivateCommand>();
        //this.fire2 = ScriptableObject.CreateInstance<DoNothing>();
        this.upward = ScriptableObject.CreateInstance<MoveCharacterUp>();
        this.downward = ScriptableObject.CreateInstance<MoveCharacterDown>();
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.booty.text = "Booty";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.fire1.Execute(this.gameObject);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            this.fire2.Execute(this.gameObject);
        }
        
        if(Input.GetAxis("Vertical") > 0.01)
        {
            this.up.Execute(this.gameObject);
        }
        if(Input.GetAxis("Vertical") < -0.01)
        {
            this.down.Execute(this.gameObject);
        }
        
        if(Input.GetAxis("Horizontal") > 0.01)
        {
            this.right.Execute(this.gameObject);
        }
        if(Input.GetAxis("Horizontal") < -0.01)
        {
            this.left.Execute(this.gameObject);
        }

        var animator = this.gameObject.GetComponent<Animator>();
        animator.SetFloat("Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));
        this.booty.text = "x" + (this.mushrooms * 1 + this.gems * 3 + this.skulls * 2);
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision);
        if (collision.gameObject.tag == "Mushroom")
        {
            Destroy(collision.gameObject);
            this.mushrooms++;
        }
        else if (collision.gameObject.tag == "Skull")
        {
            Destroy(collision.gameObject);
            this.skulls++;
        }
        else if(collision.gameObject.tag == "Gem")
        {
            Destroy(collision.gameObject);
            this.gems++;
        }
    }
    */
}
