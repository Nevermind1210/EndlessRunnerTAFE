using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public Image staminaBar;
    private Rigidbody2D rb;
    private float move;

    [SerializeField] public float moveSpeed = 10;          //Var 1
    [SerializeField] public float jumpHeight = 5;          //Var 2   
    [SerializeField] public bool grounded;
    [SerializeField] public float sprintMulti = 2;         //Var 3
    [SerializeField] public float pHealth = 5;             //Var 4
                     
    [SerializeField] public float maxFuel = 5;             //Var 5
    [SerializeField] public float currentFuel = 5;
    [SerializeField] public float jetpackForce = 10;       //Var 6
                     
    [SerializeField] public GameObject flame;
                     
                     
    [SerializeField] public float maxStamina = 10;          //Var 7
    [SerializeField] public float currentStamina = 10;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (pHealth <= 0) // Game Over.
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            move = move * sprintMulti;
            currentStamina -= 2 * Time.deltaTime;
        }
        else if (!Input.GetKey(KeyCode.LeftShift) && currentStamina < maxStamina)
        {
            currentStamina += 1 * Time.deltaTime;
        }
        //staminaBar.fillAmount = currentStamina / maxStamina; 


        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity += Vector2.up * jumpHeight;
        }
        else if (Input.GetButton("Jump") && grounded == false)
        {
            if (currentFuel > 0)
            {
                flame.SetActive(true);
                rb.velocity += Vector2.up * jetpackForce * Time.deltaTime;
                currentFuel -= Time.deltaTime;
            }
        }
        else if (Input.GetButtonUp("Jump"))
        {
            flame.SetActive(false);
        }


    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            currentFuel = maxFuel;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }


}
