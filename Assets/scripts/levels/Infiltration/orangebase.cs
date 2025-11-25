using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class orangebase : MonoBehaviour
{

    public GameObject bluezone;
    public GameObject orangezone;

    private bool capture;
    private bool p2enter;

    public float p1score;

    public Slider slide;

    private Collider2D col;


    // Start is called before the first frame update
    void Start()
    {
        bluezone.SetActive(false);
        orangezone.SetActive(true);

        col = GetComponent<Collider2D>();
        p2enter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (capture==true && p2enter == false)
        {
            bluezone.SetActive (true);
            orangezone.SetActive (false);
            p1score = p1score + 8 * Time.deltaTime;
        }
        else if (capture==false)
        {
            bluezone.SetActive (false);
            orangezone.SetActive (true);
        }

        if(capture==true && p2enter == true)
        {
            bluezone.SetActive(false);
            orangezone.SetActive(true);
        }

        slide.value = p1score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 1")
        {
            capture = true;
        }

        if (collision.gameObject.name == "Player 2")
        {
            p2enter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 1")
        {
            capture = false;
        }

        if (collision.gameObject.name == "Player 2")
        {
            p2enter = false;
        }
    }
}
