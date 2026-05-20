using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public List<GameObject> targets;

    public float spawnRate = 1.0f;

    private int score;
    private int lives;

    public bool isGameActive;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTarget());

        isGameActive = true;

        score = 0;
        UpdateScore(0);
        lives = 3;
        UpdateLives(0);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
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
        lives -= livesToLoose;
        //add life counter code
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 1)
        {
            GameOver();
        }
    }
}
