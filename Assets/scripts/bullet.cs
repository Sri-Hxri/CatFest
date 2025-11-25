using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;
    public float timetolive;

    public float Shootspeed;
   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        col = rb.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.right * Shootspeed;

        Destroy(gameObject,timetolive);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        else if(collision.gameObject.tag == "platform")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Trap")
        {
            Destroy(gameObject);
        }

    }

}
