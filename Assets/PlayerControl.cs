using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed = 0.2f;

    float verticalInput = 0;

    public float originY;

    
    // Start is called before the first frame update
    void Start()
    {
        originY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if(gameObject.tag == "Player1")
        {
            if (Input.GetKey(KeyCode.W))
            {
                verticalInput = playerSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
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
            else if (Input.GetKey(KeyCode.DownArrow))
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
    }
}
