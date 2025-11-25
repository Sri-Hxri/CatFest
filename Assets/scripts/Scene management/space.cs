using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class space : MonoBehaviour
{

    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        image.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            image.SetActive(false);
        }
    }
}
