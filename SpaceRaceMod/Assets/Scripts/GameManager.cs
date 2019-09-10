using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int gameState;
    //0 = Menu
    //1 = Game

    public int p1Score;
    public int p2Score;

    public float timerNum = 120;

    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;
    
    public Canvas playText;

    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        p1ScoreText = GameObject.Find("P1Score").GetComponent<TextMeshProUGUI>();
        p2ScoreText = GameObject.Find("P2Score").GetComponent<TextMeshProUGUI>();

        playText = GameObject.Find("PlayTextCanvas").GetComponent<Canvas>();

        timerText = GameObject.Find("TimerNum").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();

        if(gameState == 0)
        {
            playText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameState++;

                p1Score = 0;
                p2Score = 0;

                timerNum = 120;
            }
        }
        if(gameState == 1)
        {
            playText.gameObject.SetActive(false);

            timerNum -= Time.deltaTime;
            timerText.text = Mathf.Round(timerNum).ToString();

            if(timerNum <= 0)
            {
                gameState--;
            }
        }
    }
}
