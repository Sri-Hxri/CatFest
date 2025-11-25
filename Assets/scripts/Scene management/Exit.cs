using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player 1" && collision.gameObject.name == "Player 2" && Input.GetKey(KeyCode.KeypadEnter))
        {
            Application.Quit();
        }
    }
}
