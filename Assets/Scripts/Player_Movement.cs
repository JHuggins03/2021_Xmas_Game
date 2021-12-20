using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float height;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    //Grabs refrences from objects
    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }







    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    private void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,body.velocity.y);

        // flip player
        if  (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);



        if(Input.GetKey(KeyCode.Space) && grounded){
            Jump();
        }


        //set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, height);
        anim.SetTrigger("jump");
        grounded = false;

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground")
            grounded = true;
    }

}
