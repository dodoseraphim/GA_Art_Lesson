using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 1;

    public float jumpForce = 1;

    public float groundCheckDistance = 0.5f;

    SpriteRenderer sprite = null;

    Rigidbody2D rb = null;

    float scaleX = 1;
    
    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
     sprite = GetComponentInChildren<SpriteRenderer>();
     scaleX = transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        //set the speed for left and right but don't mess with up and down
        rb.velocity = Vector2.right * Input.GetAxis("Horizontal") * speed + Vector2.up * rb.velocity.y;

        //flip the sprite to the set direction
        if(Input.GetAxis("Horizontal") != 0) {
            int direction = 1;
            if (Input.GetAxis("Horizontal") < 0) {
                direction = -1;
            }
            transform.localScale = new Vector3(scaleX * direction, transform.localScale.y, transform.localScale.z);
           
        } 
        //Make sure char is on the ground by checking the distance from char downwards
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);
        //if there is groung close enought you aren't in the air
        inAir = hit.collider ==null; 

        //if the char is on te ground and "jump" space bar is pushed the char jumps
        if (!inAir && Input.GetButtownDown("Jump")) {
            transform.position += Vector3.up * 0.1f;
            rb.AddForce(Vector2.up * jumpForce)
        }
    }
}
