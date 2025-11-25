using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class bluebase : MonoBehaviour
{
    public GameObject bluezone;
    public GameObject orangezone;

    private bool capture;
    private bool p1enter;

    public float p2score;

    public Slider slide;

    private Collider2D col;


    // Start is called before the first frame update
    void Start()
    {

        bluezone.SetActive(true);
        orangezone.SetActive(false);


        col = GetComponent<Collider2D>();
        p1enter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (capture == true && p1enter == false)
        {

            bluezone.SetActive(false);
            orangezone.SetActive(true);
            p2score = p2score + 8 * Time.deltaTime;
        }

        else if (capture == false)
        {
            bluezone.SetActive(true);
            orangezone.SetActive(false);
        }

        if (capture == true && p1enter == true)
        {   
            bluezone.SetActive(true);
            orangezone.SetActive(false);
        }

        slide.value = p2score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 2")
        {
            capture = true;
        }

        if (collision.gameObject.name == "Player 1")
        {
            p1enter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 2")
        {
            capture = false;
        }

        if (collision.gameObject.name == "Player 1")
        {
            p1enter = false;
        }
    }
}
