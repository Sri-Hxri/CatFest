using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreboard : MonoBehaviour
{
    private int scenenum;
    // Start is called before the first frame update
    void Start()
    {
       scenenum = PlayerPrefs.GetInt("scene");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene(scenenum);
        }
    }
}
