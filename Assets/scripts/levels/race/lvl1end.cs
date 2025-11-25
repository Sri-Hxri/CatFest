    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl1end : MonoBehaviour
{

    public static lvl1end lvl1;
     
    public int Player1score;
    public int Player2score;

    private Collider2D col;
   


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();

        Player1score = PlayerPrefs.GetInt("player1score", 0);
        Player2score = PlayerPrefs.GetInt("player2score", 0);

        PlayerPrefs.SetInt("scene", 3);


    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 1")
        {

            Player1score = Player1score +1;

            PlayerPrefs.SetInt("player1score", Player1score);

            SceneManager.LoadScene(7);
           
        }

        if (collision.gameObject.name == "Player 2")
        {
            Player2score = Player2score + 1;

            PlayerPrefs.SetInt("player2score", Player2score);

            SceneManager.LoadScene(7);
          
        }
    }
}
