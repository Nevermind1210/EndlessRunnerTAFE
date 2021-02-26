using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticles : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //player takes damage
            other.GetComponent<PlayerController>().pHealth -= damage;
            Debug.Log(other.GetComponent<PlayerController>().pHealth);
            Destroy(gameObject);
        }
    }
}
