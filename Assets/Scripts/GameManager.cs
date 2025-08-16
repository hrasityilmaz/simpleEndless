using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject GameOverPanel;
    public TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        GameOverPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        ObstacleSpawner.instance.gameOver = true;
        StopScrolling();
        GameOverPanel.SetActive(true);
    }

    public void StopScrolling()
    {
        TextureScroll[] scrollingObjects = FindObjectsOfType<TextureScroll>();
        foreach (TextureScroll t in scrollingObjects)
        {
            t.scroll = false;
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
