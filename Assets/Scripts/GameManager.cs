using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    int leftScore;
    int rightScore;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI gameOverText;
    AudioSource scoreSound;
    public bool playing;
    public bool rightScoredLast;
    public Ball ballScript;
    GameObject ball;
    int timer;

    void Start()
    {
        scoreSound = GetComponents<AudioSource>()[1];
        playing = true;
        leftScore = 0;
        rightScore = 0;
        rightScoredLast = true;
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
        gameOverText.text = "";
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        ball = GameObject.FindGameObjectWithTag("Ball");
        timer = 301;
    }

    public void goal(bool input) {
        if (input) {
            leftScore += 1;
            leftScoreText.text = leftScore.ToString();
            rightScoredLast = false;
            gameOverText.text = "Player 1 scores!";
        }
        else {
            rightScore += 1;
            rightScoreText.text = rightScore.ToString();
            rightScoredLast = true;
            gameOverText.text = "Player 2 scores!";
        }
        scoreSound.Play();
        ball.SetActive(false);
        timer = 0;
        playing = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 300) {
            timer += 1;
        }
        if (timer == 300) {
            playing = true;
            gameOverText.text = "";
            timer = 301;
        }

        if (playing) {
            ballScript.direction = ballScript.launch(!rightScoredLast);
            ballScript.ballSpeed = ballScript.newSpeed();
            ball.SetActive(true);
            playing = false;
        }

        if (leftScore > 4)
        {
            timer = 101;
            gameOverText.text = "Player 1 wins!";
        }

        if (rightScore > 4) {
            timer = 101;
            gameOverText.text = "Player 2 wins!";
        }
    }
}
