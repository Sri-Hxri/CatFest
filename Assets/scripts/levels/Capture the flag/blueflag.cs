using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class blueflag : MonoBehaviour
{

    public GameObject capturezone;

    public Transform flagpoint;


    public Transform flagholder;

    public bool flagyes;

    public Player2 p2;


    // Start is called before the first frame update
    void Start()
    {
        capturezone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        flagyes = p2.p2hasflag;

        if (flagyes == true)
        {
            capturezone.SetActive(true);
            transform.position = flagholder.position;
        }
        else if (flagyes == false)
        {
            capturezone.SetActive(false);
            transform.position = flagpoint.position;
        }
    }
}
