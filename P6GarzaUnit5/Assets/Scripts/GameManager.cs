using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NUnit.Framework.Constraints;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    //Audio Stuff
    public float spawnRate = 1.0f;
    public float audioSpeed;
    private bool audioCheck;
    public GameObject TitleTheme;
    public GameObject PlayTheme;
    AudioSource TitleMusic;
    AudioSource PlayMusic;


    //UI Numbers
    private int score;
    public int lives;

    //Active Game
    public bool isGameActive;

    //UI bulshit
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI lifeText;
    public Button restartButton;
    public GameObject titleMeanie;
    public GameObject UserI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      TitleMusic = TitleTheme.GetComponent<AudioSource>();
      PlayMusic = PlayTheme.GetComponent<AudioSource>();

        TitleMusic.Play();
        TitleMusic.pitch = 1;
        audioCheck = false;
    }
    public void StartGame(int difficultySet)
    {
        //Play the correct song at the start
        TitleMusic.Stop();
        TitleMusic.pitch = 0;
        PlayMusic.Play();
        audioCheck = true;

        //Start the spawn!
        StartCoroutine(SpawnTarget());

        spawnRate /= difficultySet;

        //UI and game active
        isGameActive = true;
        UserI.gameObject.SetActive(true);
        titleMeanie.gameObject.SetActive(false);

        //UI numbers
        score = 0;
        UpdateScore(0);
        lives = 3;
        UpdateLives(0);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Hunger Points Satiated: " + score;
    }

    public void UpdateLives(int livesToLoose)
    {
        lives += livesToLoose;
        lifeText.text = "Energy Left: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 1)
        {
            GameOver();
        }
        if (score < 0)
        {
            score = 0;
        }

        if (audioCheck == true)
        {
            PlayMusic.pitch = audioSpeed;
        }
    }
}
