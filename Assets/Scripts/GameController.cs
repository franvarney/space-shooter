using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public int hazardCount;
    public Vector3 spawnValues;
    public float spawnWait;
    public float waveWait;

    public GameObject gameOverText;
    public GameObject restartText;
    public GameObject scoreText;

    private bool gameOver;
    private bool restart;
    private int score;

    private Text GameOverText {
        get {
            return gameOverText.GetComponent<Text>();
        }
    }

    private Text RestartText {
        get {
            return restartText.GetComponent<Text>();
        }
    }

    private Text ScoreText {
        get {
            return scoreText.GetComponent<Text>();
        }
    }

    IEnumerator SpawnWaves () {
        yield return new WaitForSeconds(spawnWait);

        while (true) {
            for (int index = 0; index < hazardCount; ++index) {
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver) {
                RestartText.text = "'R' to restart";
                restart = true;
                break;
            }
        }
    }

	void Start () {
        gameOver = false;
        GameOverText.text = "";
        RestartText.text = "";
        score = 0;

        UpdateScore();
        StartCoroutine(SpawnWaves());
	}

    public void AddScore (int newScore) {
        score += newScore;
        UpdateScore();
    }
    
    void UpdateScore () {
        ScoreText.text = "Score: " + score; 
    }

    public void GameOver ()  {
        GameOverText.text = "Game Over";
        gameOver = true;
    }

    void Update () {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene("SpaceShooter");
            }
        }
    }
}
