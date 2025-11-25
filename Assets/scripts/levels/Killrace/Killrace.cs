using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killrace : MonoBehaviour
{

    //score

    public GameObject p1heart1;
    public GameObject p1heart2;
    public GameObject p1heart3;



    public GameObject p2heart1;
    public GameObject p2heart2;
    public GameObject p2heart3;


    public float p1count;
    public float p2count;

    public Player1 p1;
    public Player2 p2;

    private int p1sc;
    private int p2sc;

    // Start is called before the first frame update
    void Start()
    {
        p1heart1.SetActive(true);
        p1heart2.SetActive(true);
        p1heart3.SetActive(true);


        p2heart1.SetActive(true);
        p2heart2.SetActive(true);
        p2heart3.SetActive(true);


        p1sc = PlayerPrefs.GetInt("player1score");
        p2sc = PlayerPrefs.GetInt("player2score");

        PlayerPrefs.SetInt("scene", 5);
    }

    // Update is called once per frame
    void Update()
    {
        if(p1count==1)
        {
            p1heart3.SetActive (false);
        }
        else if (p1count == 2)
        {
            p1heart2.SetActive(false);
        }
        else if (p1count == 3)
        {
            p1heart1.SetActive(false);
        }
        



        if (p2count == 1)
        {
            p2heart3.SetActive(false);
        }
        else if (p2count == 2)
        {
            p2heart2.SetActive(false);
        }
        else if (p2count == 3)
        {
            p2heart1.SetActive(false);
        }
  




        p1count = p1.deathcountP1;

        p2count = p2.deathcountP2;

        if (p1count > 2)
        {
            p2sc = p2sc + 1;

            PlayerPrefs.SetInt("player2score", p2sc);

            SceneManager.LoadScene(7);
        }

        if (p2count > 2)
        {
            p1sc = p1sc + 1;

            PlayerPrefs.SetInt("player1score", p1sc);

            SceneManager.LoadScene(7);
        }
    }
}
