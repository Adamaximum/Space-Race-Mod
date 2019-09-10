using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public GameManager gm;

    public AudioSource Layer3;
    public AudioSource Layer4;
    public AudioSource Layer5;
    public AudioSource Layer6;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState > 0)
        {
            Layer3.mute = false;
        }
        if (gm.timerNum <= 80)
        {
            Layer4.mute = false;
        }
        if (gm.timerNum <= 40)
        {
            Layer5.mute = false;
        }
        if (gm.timerNum <= 0)
        {
            Layer6.mute = false;
        }
    }
}
