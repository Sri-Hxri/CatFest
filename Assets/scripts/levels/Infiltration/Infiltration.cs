using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Infiltration : MonoBehaviour
{
    public bluebase p2;
    public orangebase p1;

    private float p1score;
    private float p2score;

    private int p1sc;
    private int p2sc;

    // Start is called before the first frame update
    void Start()
    {
        p1sc = PlayerPrefs.GetInt("player1score");
        p2sc = PlayerPrefs.GetInt("player2score");

        PlayerPrefs.SetInt("scene", 0);
    }

    // Update is called once per frame
    void Update()
    {
        p1score = p1.p1score;
        p2score = p2.p2score;

        if(p1score > 100)
        {
            p1sc = p1sc + 1;
            PlayerPrefs.SetInt("player1score", p1sc);

            if(p1sc>p2sc)
            {
                SceneManager.LoadScene(7);
            }
            else if(p2sc>p1sc)
            {
                SceneManager.LoadScene(7);
            }

        }
        else if (p2score > 100)
        {
            p2sc = p2sc + 1;
            PlayerPrefs.SetInt("player2score", p2sc);

            if (p1sc > p2sc)
            {
                SceneManager.LoadScene(7);
            }
            else if (p2sc > p1sc)
            {
                SceneManager.LoadScene(7);
            }
        }


    }
}
