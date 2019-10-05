using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour {
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public bool isGrounded;
    public Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        animator.SetFloat("Speed", Mathf.Abs(move.x * moveSpeed));
        transform.position += move * Time.deltaTime * moveSpeed;

        if (move.x < 0)
            spriteRenderer.flipX = true;
        else if (move.x > 0)
            spriteRenderer.flipX = false;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
    }



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
