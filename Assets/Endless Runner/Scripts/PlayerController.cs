using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask platLayerMask;
    public Rigidbody2D rb2D;
    private BoxCollider2D boxCollider2D;
    [SerializeField]float moveSpeed = 10f;

    private void Awake()
    {
        rb2D.transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if ( IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rb2D.velocity = Vector2.up * jumpVelocity;
        }

        HandleMovement();
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down , .1f, platLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.velocity = new Vector2(-moveSpeed, rb2D.velocity.y);
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.velocity = new Vector2(+moveSpeed, rb2D.velocity.y);
        } else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
            
    }

    private void HandleMovement2() // this one removes control once in air.
    {
        float midAirControl = 1f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (IsGrounded())
            {
                rb2D.velocity = new Vector2(-moveSpeed, rb2D.velocity.y);
            }
            else
            {             
                rb2D.velocity += new Vector2(-moveSpeed * Time.deltaTime, 0);
                rb2D.velocity = new Vector2(Mathf.Clamp(rb2D.velocity.x, -moveSpeed, +moveSpeed), rb2D.velocity.y);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if(IsGrounded())
                {
                    rb2D.velocity = new Vector2(+moveSpeed, rb2D.velocity.y);
                } else
                {
                    rb2D.velocity += new Vector2(+moveSpeed * Time.deltaTime, 0);
                    rb2D.velocity = new Vector2(Mathf.Clamp(rb2D.velocity.x, -moveSpeed, +moveSpeed), rb2D.velocity.y);
                }
            }
            else
            {
                // No Keys Pressed
                if (IsGrounded())
                {
                    rb2D.velocity = new Vector2(0, rb2D.velocity.y);
                }
            }
        }
    }
}
