using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int p1Score;
    public int p2Score;

    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        p1ScoreText = GameObject.Find("P1Score").GetComponent<TextMeshProUGUI>();
        p2ScoreText = GameObject.Find("P2Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();
    }
}
