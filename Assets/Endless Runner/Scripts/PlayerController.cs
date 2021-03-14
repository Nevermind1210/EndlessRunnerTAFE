using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D.transform.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rb2D.velocity = Vector2.up * jumpVelocity;
        }
    }
}
