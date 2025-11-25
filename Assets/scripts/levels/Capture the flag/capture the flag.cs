using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class capturetheflag : MonoBehaviour
{
    public Player1 p1;
    public Player2 p2;

    private int p1sc;
    private int p2sc;

    public int score1;
    public int score2;

    public GameObject p1flag1;


    public GameObject p2flag1;

    // Start is called before the first frame update
    void Start()
    {
        p1flag1.SetActive(true);


        p2flag1.SetActive(true);

            
        

        p1sc = PlayerPrefs.GetInt("player1score");
        p2sc = PlayerPrefs.GetInt("player2score");

        PlayerPrefs.SetInt("scene", 6);
    }

    // Update is called once per frame
    void Update()
    {
        if(score2 ==1)
        {
            p1flag1.SetActive(false);
        }
        else if(score1 ==1)
        {
            p2flag1.SetActive(false);
        }





        score1 = p1.p1curscore;

        score2 = p2.p2curscore;

        if(score1 == 1)
        {
            p1sc = p1sc + 1;
            PlayerPrefs.SetInt("player1score", p1sc);
            SceneManager.LoadScene(7);
        }
        else if (score2 == 1)
        {
            p2sc = p2sc + 1;
            PlayerPrefs.SetInt("player2score", p2sc);
            SceneManager.LoadScene(7);
        }
    }
}
