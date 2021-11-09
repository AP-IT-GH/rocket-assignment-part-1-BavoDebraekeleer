using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject canvasMain;
    public GameObject canvasGameOver;
    public enum GameStates
    {
        Playing,
        GameOver
    }
    public GameStates gameState = GameStates.Playing;

    private Health healthPlayer;
    public Text textHealth;
    public string healthPrefix = "Health: ";

    private int score;
    public Text textScore;
    public string scorePrefix = "Score: ";

    // Start is called before the first frame update
    void Start()
    {
        if(player == null) player = GameObject.FindWithTag("Player");
        healthPlayer = player.GetComponent<Health>();
        canvasMain.SetActive(true);
        canvasGameOver.SetActive(false);

        score = 0;
        textScore.text = scorePrefix + score;
        textHealth.text = healthPrefix + healthPlayer.healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        // Game State Machine
        switch (gameState)
        {
            case GameStates.Playing:
                if (!healthPlayer.isAlive)
                {
                    gameState = GameStates.GameOver;
                    canvasMain.SetActive(false);
                    canvasGameOver.SetActive(true);
                    Debug.Log("Set GameOver");
                }
                break;
            case GameStates.GameOver:
                break;
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        textScore.text = scorePrefix + score;
    }
}
