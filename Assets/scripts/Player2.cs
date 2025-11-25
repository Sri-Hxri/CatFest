using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Player2 p2;

    [SerializeField] private float Movespeed;
    private bool facingright;

    private Rigidbody2D rb;
    private Collider2D col;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float Jumpspeed;
    private float jumpcount;

    public Transform groundcheck;
    private bool isgrounded;
    private float GCradius = 0.2f;

    //animation

    public Animator anim;


    //shoot

    public Transform firepoint;
    public GameObject Bulletprefab;
    public float Shootspeed;
    float shootdelay = 1;

    //sound

    [SerializeField] private AudioSource jumpsound;
    [SerializeField] private AudioSource shootsound;


    //KILLRACE

    public float deathcountP2;


    //capture the flag

    public bool p2hasflag;
    public int p2curscore;

    //respawn
    public Transform respawnpoint;

    //checkpoints
    public GameObject checkpoint1;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("player2flag", 0);
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        facingright = true;
    }



    // Update is called once per frame
    void Update()
    {
        groundchecks();

        //Movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.Translate(Vector2.right * Movespeed * Time.deltaTime);
            rb.linearVelocity = new Vector2(-Movespeed, rb.linearVelocity.y);

        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //transform.Translate(Vector2.right * Movespeed * Time.deltaTime);
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            anim.SetFloat("run", 0);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = new Vector2(Movespeed, rb.linearVelocity.y);

        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //transform.Translate(Vector2.right * Movespeed * Time.deltaTime);
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            anim.SetFloat("run", 0);

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpcount > 0)
        {
            jumpsound.Play();
            rb.AddForce(Vector2.up * Jumpspeed, ForceMode2D.Impulse);
            jumpcount--;    
        }

        if (isgrounded == false)
        {
            Movespeed = 5;
            Jumpspeed = 5;
        }
        else if (isgrounded == true)
        {
            Movespeed = 8;
            Jumpspeed = 10;
        }

        //flip

        if (Input.GetKeyDown(KeyCode.LeftArrow) && facingright == true)
        {
            flip();
            facingright = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && facingright == false)
        {
            flip();
            facingright = true;
        }


        //shoot

        if (Input.GetKeyUp(KeyCode.RightControl) && shootdelay>0)
        {
            shootsound.Play();
            shoot();

        }



        //animation

        if (Input.GetKey(KeyCode.LeftArrow) && isgrounded == true)
        {
            anim.SetFloat("run", 1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && isgrounded == false)
        {
            anim.SetFloat("run", 0);
        }


        if (Input.GetKey(KeyCode.RightArrow) && isgrounded == true)
        {
            anim.SetFloat("run", 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && isgrounded == false)
        {
            anim.SetFloat("run", 0);
        }

        if (isgrounded == false)

        {

            anim.SetFloat("jump", 1);
        }
        else if (isgrounded == true)

        {

            anim.SetFloat("jump", 0);
        }
    }

    public void shoottime()
    {
        shootdelay = 0.5f;
    }

    public void shoot()
    {
        Instantiate(Bulletprefab, firepoint.position, transform.rotation);

        shootdelay = 0;

        Invoke("shoottime", 1);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bluebullet")
        {
            transform.position = respawnpoint.transform.position;
            deathcountP2 = deathcountP2 + 1;

        }
        else if ((collision.gameObject.tag == "Trap"))
        {
            transform.position = respawnpoint.transform.position;
        }

        if ((collision.gameObject == checkpoint1))
        {
            respawnpoint.transform.position = checkpoint1.transform.position;
        }

        //capture flag

        if (collision.gameObject.name == "blueflag")
        {
            p2hasflag = true;
        }

        if(collision.gameObject.tag =="bluebullet"&&p2hasflag ==true)
        {
            p2hasflag=false;

        }
        else if (collision.gameObject.tag == "Trap" && p2hasflag == true)
        {
            p2hasflag = false;

        }

        if (collision.gameObject.name == "orangeflagpoint" && p2hasflag == true)
        {
            p2curscore = p2curscore + 1;
            p2hasflag = false;
        }
    }


    private bool Grounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, ground);
    }

    //groundcheck
    void groundchecks()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundcheck.position, GCradius, ground);

        if (colliders.Length > 0)
        {
            isgrounded = true;
            jumpcount = 1;
        }
        else

        {
            isgrounded = false;

        }
    }


    void flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
