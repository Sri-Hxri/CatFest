using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour

{
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


    //shoot

    public Transform firepoint;
    public GameObject Bulletprefab;
    public float shootdelay = 0;


    //sound

    [SerializeField] private AudioSource jumpsound;
    [SerializeField] private AudioSource shootsound;
   

    //kill race

    public float deathcountP1 = 0;


    //capture the flag

    public bool hasflag;

    public int p1curscore;

    //animator
    public Animator anim;

    //respawn
    public Transform respawnpoint;


    //checkpoints
    public GameObject Checkpoint1;


    // Start is called before the first frame update
    void Start()
    {

        PlayerPrefs.GetInt("player1flag", 0);
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
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(Vector2.right * Movespeed * Time.deltaTime);
            rb.linearVelocity = new Vector2(-Movespeed, rb.linearVelocity.y);
            

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            //transform.Translate(Vector2.right * Movespeed * Time.deltaTime);
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            anim.SetFloat("run", 0);
            

        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(Movespeed, rb.linearVelocity.y);

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            //transform.Translate(Vector2.right * Movespeed * Time.deltaTime);
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            anim.SetFloat("run", 0);
           
        }


        if (Input.GetKeyDown(KeyCode.W) && jumpcount>0)
        {
            jumpsound.Play();
            rb.AddForce(Vector2.up * Jumpspeed, ForceMode2D.Impulse);
            jumpcount--;
        }

        if (isgrounded ==false)
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

        if (Input.GetKeyDown(KeyCode.A) && facingright == true)
        {
            flip();
            facingright = false;
        }

        if (Input.GetKeyDown(KeyCode.D) && facingright == false)
        {
            flip();
            facingright = true;
        }


        //shoot

        if (Input.GetKeyUp(KeyCode.LeftControl) && shootdelay>0)
        {
            shootsound.Play();
            shoot();
        }




        //animation

        if (Input.GetKey(KeyCode.A) && isgrounded == true)
        {
            anim.SetFloat("run", 1);
           

        }
        else if (Input.GetKey(KeyCode.A) && isgrounded == false)
        {
            anim.SetFloat("run", 0);
           
        }


        if (Input.GetKey(KeyCode.D) && isgrounded == true)
        {
            anim.SetFloat("run", 1);
           
        }
        else if (Input.GetKey(KeyCode.D) && isgrounded == false)
        {
            anim.SetFloat("run", 0);
            
        }

        if(isgrounded == false)
        
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
       Instantiate(Bulletprefab, firepoint.position, transform.rotation );
        shootdelay = 0;

        Invoke("shoottime", 1);

    }







    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "orangebullet")
        {
           
            deathcountP1++;
            transform.position = respawnpoint.transform.position;
           
        }

        else if ((collision.gameObject.tag == "Trap"))
        {
            transform.position = respawnpoint.transform.position;
        }


        if ((collision.gameObject == Checkpoint1))
        {
            respawnpoint.transform.position = Checkpoint1.transform.position;
        }

        //capturetheflag


        if (collision.gameObject.name == "orangeflag")
        {
            hasflag = true;
        }

        if (collision.gameObject.tag == "orangebullet" && hasflag == true)
        {
            hasflag = false;
           
        }
        else if (collision.gameObject.tag == "Trap" && hasflag == true)
        {
            hasflag = false;

        }

        if (collision.gameObject.name == "Blueflagpoint" && hasflag == true)
        {
            p1curscore = p1curscore + 1;
            hasflag = false;
        }
    }

    //flipS
    void flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    //box cast

    

    //ground check

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


}
