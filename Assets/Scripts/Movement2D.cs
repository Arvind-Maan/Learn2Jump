using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour {
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public bool isGrounded;
    public bool isBlocking;
    public bool isAttacking;
    public Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //initialize variables;
        spriteRenderer = GetComponent<SpriteRenderer>();
        isGrounded = isBlocking = isAttacking = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //check for any actions
        Act();
        //movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //tell the animator we are moving
        animator.SetFloat("Speed", Mathf.Abs(move.x * moveSpeed));
        //change position
        transform.position += move * Time.deltaTime * moveSpeed;

        //flip sprite when we are moving left.
        if (move.x < 0)
            spriteRenderer.flipX = true;
        else if (move.x > 0)
            spriteRenderer.flipX = false;
    } //end of update

    void Act()
    {
        //the key inputs that the player can respond to
        if (Input.GetButtonDown("Jump") && isGrounded) //jump
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) //block
            isBlocking = true;
        else if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Z)) // attack
            isAttacking = true;
        else
        { 
            isBlocking = false;
            isAttacking = false;
        }
        animator.SetBool("Attack", isAttacking);
        animator.SetBool("Block", isBlocking);
    } //end of act


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            isGrounded = false;
    }

}
