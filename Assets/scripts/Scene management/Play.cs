using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    private Collider2D col;
    private bool p1;
    private bool p2;
    public GameObject text;


    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (p1 == true && p2 == true)
        {
            text.SetActive(true);

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name== "Player 1")
        {
           p1 = true;
        }

        if (collision.gameObject.name == "Player 2")
        {
            p2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 1")
        {
            p1 = false;
        }

        if (collision.gameObject.name == "Player 2")
        {
            p2 = false;
        }
    }

}
