using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    int crown = 0;
    bool ground = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.W))
        {
            jumper ();
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetInteger("animashka", 1);
        }
        else
        {
            Flip();
            anim.SetInteger("animashka", 2);
        }
        

    }
    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 3f, rb.velocity.y);
    }

    void jumper()
    {
        rb.AddForce(transform.up * 5f, ForceMode2D.Impulse);
    }
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), "Crown = " + crown);
    }

    private void OnTriggerEnter2D(Collider2D coin)
    {
        if (coin.gameObject.tag == "coin")
        {
            crown++;
            Destroy(coin.gameObject);
        }
        if (coin.gameObject.tag == "Finish")
        {
            Application.LoadLevel("lvl2");
        }
        if (coin.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene(0);
        }
        if (coin.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(1);
        }
        if (coin.gameObject.tag == "finish2")
        {
            SceneManager.LoadScene(2);
        }
        if (coin.gameObject.tag == "game over")
        {
            SceneManager.LoadScene(3);
        }
    }


}
