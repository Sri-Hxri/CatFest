using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    private Collider2D col;
    private bool P1;
    private bool P2;

    public GameObject space;
    // Start is called before the first frame update
    void Start()
    {
       PlayerPrefs.GetInt("player1score", 0);
       PlayerPrefs.GetInt("player2score", 0);

        PlayerPrefs.GetInt("scene", 0);

        PlayerPrefs.SetInt("player1score", 0);
        PlayerPrefs.SetInt("player2score", 0);
        
        col = GetComponent<Collider2D>();
        space.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (P1 == true && P2 == true)
        {
            space.SetActive(true);

            if (Input.GetKeyUp(KeyCode.Space))
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 1")
        {
            P1 = true;
        }
        else if (collision.gameObject.name == "Player 2")
        {
            P2 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 1")
        {
            P1 = false;
        }
        else if (collision.gameObject.name == "Player 2")
        {
            P2 = false;
        }
    }
}
