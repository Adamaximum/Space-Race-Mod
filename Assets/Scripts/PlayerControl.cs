using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameManager gm;

    public float playerSpeed = 0.2f;

    float verticalInput = 0;

    public float originY;

    bool border;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        originY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState == 1)
        {
            PlayerMove();
        }
        else
        {
            transform.position = new Vector3(transform.position.x, originY, 0);
        }

        if (transform.position.y < originY)
        {
            border = true;
        }
        else
        {
            border = false;
        }
    }

    void PlayerMove()
    {
        if(gameObject.tag == "Player1")
        {
            if (Input.GetKey(KeyCode.W))
            {
                verticalInput = playerSpeed;
            }
            else if (Input.GetKey(KeyCode.S) && border == false)
            {
                verticalInput = -playerSpeed;
            }
            else
            {
                verticalInput = 0;
            }

            transform.position += new Vector3(0, verticalInput, transform.position.z);
        }
        if (gameObject.tag == "Player2")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                verticalInput = playerSpeed;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && border == false)
            {
                verticalInput = -playerSpeed;
            }
            else
            {
                verticalInput = 0;
            }

            transform.position += new Vector3(0, verticalInput, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Righty" || collision.gameObject.tag == "Lefty")
        {
            transform.position = new Vector3(transform.position.x, originY, 0);
        }

        if(collision.gameObject.tag == "RespawnTop")
        {
            transform.position = new Vector3(transform.position.x, originY, 0);
            if (gameObject.tag == "Player1")
            {
                gm.p1Score++;
            }
            if (gameObject.tag == "Player2")
            {
                gm.p2Score++;
            }
        }
    }
}
