using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //eventual use...

public class PlayerController : MonoBehaviour
{
    public Image staminaBar;

    private float move;
    public int pHealth = 3;
    [SerializeField] private bool grounded;
    [SerializeField] private float speed = 10;
    [SerializeField] private float maxStamina = 10;
    [SerializeField] private float currentStamina = 10;
    [SerializeField] private float sprintMulti = 2;
    [SerializeField] private GameObject stamBar;
    [SerializeField] private float jumpHeight = 3;


    public Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stamBar.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            move = move * sprintMulti;
            currentStamina -= 2 * Time.deltaTime;
        }
        else if (!Input.GetKey(KeyCode.LeftShift) && currentStamina < maxStamina)
        {
            currentStamina += 1 * Time.deltaTime;
        }
        staminaBar.fillAmount = currentStamina / maxStamina;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity += Vector2.up * jumpHeight;
        }

        void FixedUpdate()
        {
            rb.velocity = new Vector2(move, rb.velocity.y);
        }

        void OnCollisionExit2D(Collision2D collision) // This shuould disable jumping on air
        {
            grounded = false;
        }

    }
}
