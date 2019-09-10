using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int gameState;
    //0 = Menu
    //1 = Game
    //2 = End

    public int p1Score;
    public int p2Score;

    public float timerNum = 120;

    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;
    
    public Canvas playText;
    public TextMeshProUGUI pressPlay;
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        p1ScoreText = GameObject.Find("P1Score").GetComponent<TextMeshProUGUI>();
        p2ScoreText = GameObject.Find("P2Score").GetComponent<TextMeshProUGUI>();

        playText = GameObject.Find("PlayTextCanvas").GetComponent<Canvas>();
        pressPlay = GameObject.Find("PlayButton").GetComponent<TextMeshProUGUI>();
        timerText = GameObject.Find("TimerNum").GetComponent<TextMeshProUGUI>();

        winText = GameObject.Find("PlayerWins").GetComponent<TextMeshProUGUI>();

        winText.text = "";
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
            }
        }
        if(gameState == 1)
        {
            playText.gameObject.SetActive(false);

            timerNum -= Time.deltaTime;
            timerText.text = Mathf.Round(timerNum).ToString();

            if(timerNum <= 0)
            {
                gameState++;
            }
        }
        if (gameState == 2)
        {
            playText.gameObject.SetActive(true);
            pressPlay.text = "Press R to Restart";

            if(p1Score > p2Score)
            {
                winText.text = "Player 1 Wins!";
            }
            else if (p1Score < p2Score)
            {
                winText.text = "Player 2 Wins!";
            }
            else if (p1Score == p2Score)
            {
                winText.text = "Game is a Tie!";
            }

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("Mod");
            }
        }
    }
}
