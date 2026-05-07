using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static Action PointAdded;

    private Text scoreText;
    private Animator scoreAnimation;
    [SerializeField]
    private float multiplier = 1f;
    private float timer = 0f;
    private int lastSecond = 0;
    [SerializeField]
    private float multiplicationAngle = 90f;
    public static int Score { get; private set; }
    public static int playerBestScore = 0;

    [SerializeField]
    private GameObject stick;

    private void Awake()
    {
        playerBestScore = PlayerPrefs.GetInt("PlayerBestScore");
        scoreText = GetComponent<Text>();
        scoreAnimation = GetComponent<Animator>();
    }

    void Update() => CountScore();

    private void CountScore()
    {
        multiplier = 1f;
        scoreAnimation.SetBool("Multiplication", false);
        float stickAngleZ = stick.transform.eulerAngles.z;
        if (stickAngleZ >= 360 - multiplicationAngle / 2 || stickAngleZ <= multiplicationAngle / 2)
        {
            multiplier = 3f;
            scoreAnimation.SetBool("Multiplication", true);
        }
        timer += multiplier * Time.deltaTime;

        Score = Mathf.FloorToInt(timer);
        if (Score != lastSecond)
        {
            scoreText.text = Score.ToString();

            lastSecond = Score;

            PointAdded?.Invoke();
        }
    }
}