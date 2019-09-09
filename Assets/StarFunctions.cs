using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFunctions : MonoBehaviour
{
    float starSpeed = 0.03f;
    float horizontalMovement;
    
    float resetXRight = -7.9f;
    float resetXLeft = 7.9f;
    
    // Update is called once per frame
    void Update()
    {
        StarMovement();
    }

    void StarMovement()
    {
        if(gameObject.tag == "Righty")
        {
            horizontalMovement = starSpeed;

            transform.position += new Vector3(horizontalMovement, 0, transform.position.z);
        }
        if (gameObject.tag == "Lefty")
        {
            horizontalMovement = -starSpeed;

            transform.position += new Vector3(horizontalMovement, 0, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RespawnRight")
        {
            transform.position = new Vector3(-7.9f, transform.position.y, 0);
        }
        if (collision.gameObject.tag == "RespawnLeft")
        {
            transform.position = new Vector3(7.9f, transform.position.y, 0);
        }
    }
}
