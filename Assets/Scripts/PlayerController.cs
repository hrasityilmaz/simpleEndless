using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public float jumpForece;

    Rigidbody2D rb;
    Animator anim;
    bool grounded;

    bool gameOver = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            if (grounded)
            {
                Jump();
            }

        }
    }

    void Jump()
    {
        grounded = false;
        rb.velocity = Vector2.up * jumpForece;
        anim.SetTrigger("Jump");
        GameManager.instance.IncrementScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            Destroy(collision.gameObject);
            anim.Play("dead");
            GameManager.instance.GameOver();
            gameOver = true;
            
        }
    }
}
