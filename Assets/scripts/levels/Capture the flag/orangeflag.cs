using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orangeflag : MonoBehaviour
{

    public GameObject capturezone;

    public Transform flagpoint;


    public Transform flagholder;

    public bool flagyes;

    public Player1 p1;


    // Start is called before the first frame update
    void Start()
    {

        capturezone.SetActive(false);

        flagyes = p1.hasflag;
    }

    // Update is called once per frame
    void Update()
    {
        flagyes = p1.hasflag;

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
