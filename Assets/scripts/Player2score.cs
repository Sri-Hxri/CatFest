using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2score : MonoBehaviour
{
    public GameObject crown1;
    public GameObject crown2;
    public GameObject crown3;
    public GameObject crown4;
    public GameObject crown5;

    public int p2score;

    // Start is called before the first frame update
    void Start()
    {
        crown1.SetActive(false);
        crown2.SetActive(false);
        crown3.SetActive(false);
        crown4.SetActive(false);
        crown5.SetActive(false);

        p2score = PlayerPrefs.GetInt("player2score");
    }

    // Update is called once per frame
    void Update()
    {

        if (p2score == 1)
        {
            crown1.SetActive(true);


        }
        else if (p2score == 2)
        {
            crown1.SetActive(true);
            crown2.SetActive(true);

        }
        else if (p2score == 3)
        {
            crown1.SetActive(true);
            crown2.SetActive(true);
            crown3.SetActive(true);

        }
        else if (p2score == 4)
        {
            crown1.SetActive(true);
            crown2.SetActive(true);
            crown3.SetActive(true);
            crown4.SetActive(true);

        }
        else if (p2score == 5)
        {

            crown1.SetActive(true);
            crown2.SetActive(true);
            crown3.SetActive(true);
            crown4.SetActive(true);
            crown5.SetActive(true);

        }
    }
}
