using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerControl : MonoBehaviour
{
    public GameManager gm;

    public float originY;
    public float posY;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        originY = transform.position.y;
        posY = originY;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameState == 1)
        {
            posY -= 0.002f;
            transform.position = new Vector3(transform.position.x, posY, 0);
        }
    }
}
