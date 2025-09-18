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
    public AudioSource scoreSound;
    public bool playing;

    void Start()
    {
        playing = true;
        leftScore = 0;
        rightScore = 0;
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
        gameOverText.text = "";
    }

    public void goal(bool input) {
        if (input) {
            leftScore += 1;
            leftScoreText.text = leftScore.ToString();
            scoreSound.Play();
        }
        if (!input) {
            rightScore += 1;
            rightScoreText.text = rightScore.ToString();
            scoreSound.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playing) { 
            
        }

        if (leftScore > 9)
        {
            playing = false;
            gameOverText.text = "Player 1 wins!";
        }

        if (rightScore > 9) {
            playing = false;
            gameOverText.text = "Player 2 wins!";
        }
    }
}
