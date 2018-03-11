using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount = 10;
    public float spawnWait;
    public float startWait;
    public  TextMesh scoreText;
    public TextMesh restartText;
    public TextMesh gameOverText;

    private bool gameOver;
    private bool restart;
    public float waveWait;
    
    private int score;
    

    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        scoreUpdate();
        StartCoroutine(SpawnWWaves());
    }

    private void Update()
    {
      if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("GameScene");
            }

        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    IEnumerator SpawnWWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
        }

    }
   

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        scoreUpdate();
    }

    void scoreUpdate()
    {
       scoreText.text = "Score: " + score;
    }

   
}
