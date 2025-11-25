using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Capturepoint : MonoBehaviour
{

    public GameObject bluezone;
    public GameObject orangezone;
    
    private Collider2D col;

    public int test;

    public float Player1points;
    public float Player2points;

    private bool Player1onplatform;
    private bool Player2onplatform;

    public Slider player1slider;
    public Slider player2slider;

    private int p1sc;
    private int p2sc;

    // Start is called before the first frame update
    void Start()
    {
        bluezone.SetActive(false);
        orangezone.SetActive(false);

        col = GetComponent<Collider2D>();

        p1sc=PlayerPrefs.GetInt("player1score");
        p2sc = PlayerPrefs.GetInt("player2score");

        PlayerPrefs.SetInt("scene", 4);
    }

    // Update is called once per frame
    void Update()
    {
        
        player1slider.value = Player1points;
        player2slider.value = Player2points;

        if (Player1onplatform==true &&Player2onplatform == false)
        {
            bluezone.SetActive (true);
            orangezone.SetActive (false);

            Player1points= Player1points + 3 *Time.deltaTime;
        }
        else if (Player1onplatform == false && Player2onplatform == true)   
        {
            bluezone.SetActive(false);
            orangezone.SetActive(true);
            Player2points = Player2points + 3 * Time.deltaTime;
        }

        if(Player1onplatform == true && Player2onplatform == true || Player2onplatform ==false && Player1onplatform == false)
        {
            bluezone.SetActive (false);
            orangezone.SetActive (false);
        }

        if (Player1points >= 50)
        {
            p1sc = p1sc + 1;

            PlayerPrefs.SetInt("player1score", p1sc);

            SceneManager.LoadScene(7);
        }
        else if (Player2points >= 50)
        {
            p2sc = p2sc + 1;
            PlayerPrefs.SetInt("player2score", p2sc);
            SceneManager.LoadScene(7);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Player 1")
        {
            Player1onplatform = true;
        }
        else if(collision.gameObject.name == "Player 2")
        {
            Player2onplatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 1")
        {
            Player1onplatform = false;
        }
        else if (collision.gameObject.name == "Player 2")
        {
            Player2onplatform = false;
        }
    }
}
