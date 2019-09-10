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

    public float shootReset;
    public float shootSpawn;

    public GameObject shootStar;

    float lowestStarPosY = -3.5f;
    float highestStarPosY = 4.7f;
    public bool shootGo;

    public AudioSource shoot;

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

        if (transform.position.y >= lowestStarPosY && transform.position.y <= highestStarPosY)
        {
            shootGo = true;
        }
        else
        {
            shootGo = false;
        }
    }

    void PlayerMove()
    {
        if(gameObject.tag == "Player1")
        {
            shootSpawn = transform.position.x + 0.4f;

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

            shootReset++;

            if (Input.GetKeyDown(KeyCode.Space) && shootReset >= 50 && shootGo == true)
            {
                Instantiate(shootStar,new Vector3(shootSpawn,transform.position.y,0), Quaternion.identity);
                shootReset = 0;

                shoot.Play();
            }
        }
        if (gameObject.tag == "Player2")
        {
            shootSpawn = transform.position.x - 0.4f;

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

            shootReset++;

            if (Input.GetKeyDown(KeyCode.RightShift) && shootReset >= 50 && shootGo == true)
            {
                Instantiate(shootStar, new Vector3(shootSpawn, transform.position.y, 0), Quaternion.identity);
                shootReset = 0;

                shoot.Play();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Righty" || collision.gameObject.tag == "Lefty")
        {
            transform.position = new Vector3(transform.position.x, originY, 0);
            if (gameObject.tag == "Player1" && gm.p1Score > 0)
            {
                gm.p1Score--;
            }
            if (gameObject.tag == "Player2" && gm.p2Score > 0)
            {
                gm.p2Score--;
            }
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
