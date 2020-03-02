using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public Text scoreText;
    public Text highScoreText;

    public float currentSpeed = 5;

    int currentScore = 0;

    [HideInInspector]
    public bool hasLost;


    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "HIGH: " + highScore.ToString();
    }


    public void SpawnBlock ()
    {
        Invoke("InstantiateBlock", 1.5f);
    }


    void InstantiateBlock ()
    {
        if (!hasLost)
        {
            float xSpawnPosition = Random.Range(-8, 8);
            Vector3 spawnPosition = new Vector3(xSpawnPosition, 5.5f, 0);

            Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
            currentScore += 1;
            scoreText.text = currentScore.ToString();
            currentSpeed += 2;

            int highScore = PlayerPrefs.GetInt("highScore", 0);
            if (currentScore > highScore)
            {
                PlayerPrefs.SetInt("highScore", currentScore);
            }
        }
    }
}
