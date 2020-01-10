using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region 
    public static GameController instance = null;
    private void Awake() {
        if(instance == null)
            instance = this;
        else
            Destroy(this);
    }
    #endregion

    public PlayerController playerController;
    public GameObject pauseUI;
    public GameObject deathScreen;

    [Header("Game UI")]
    public Text scoreText;
    public Text highScoreText;

    private bool isPaused = true;
    private int score;
    private bool isPlayerDead = false;

    private void Start() {
        isPlayerDead = false;
        playerController.enabled = true;
        pauseUI.SetActive(false);
        deathScreen.SetActive(false);
        Time.timeScale = 1;
        UpdateScore();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePausing();
        }

        if(isPlayerDead && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private void TogglePausing()
    {
        playerController.enabled = !isPaused;
        pauseUI.SetActive(isPaused);

        if(isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        isPaused = !isPaused;
    }

    private void UpdateScore()
    {
        if(score > SceneSystem.highScore)
            SceneSystem.highScore = score;
        
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "HighScore: " + SceneSystem.highScore.ToString();

        if(score % 50 == 0)
            SpawnController.instance.waveSpawnAmount++;
    }

    public void AddScore(int x)
    {
        score += x;
        UpdateScore();
    }

    public void DeathScreen()
    {
        Time.timeScale = 0;
        Destroy(playerController.gameObject);
        deathScreen.SetActive(true);
        isPlayerDead = true;
    }

    private void Restart()
    {
        SceneSystem.instance.ChangeScene(1);
    }
}
