using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;
    public Text scoreText;
    public GameObject spawner, box;
    private bool game;
    public int topBoxes;
    public float boxDelay;
    private float delayClock;
    private int destroyedBoxes, spawnedBoxes;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawner = GameObject.Find("Spawner");
        if (scoreText != null)
        {
            scoreText.text = "Final Score: " + GameManager.score;
        }
        game = gameManager.IsGameActive();
        delayClock = 0;
        destroyedBoxes = 0;
        spawnedBoxes = 0;
    }

    private void Update()
    {
        if (game)
        {
            delayClock += Time.deltaTime;
            if (GameManager.score < 0)
            {
                GameManager.score = 0;
            }
            scoreText.text = "Score: " + GameManager.score;
            if (delayClock >= boxDelay && spawnedBoxes<topBoxes)
            {
                SpawnBox(Random.Range(spawner.transform.position.x - spawner.transform.localScale.x, spawner.transform.position.x + spawner.transform.localScale.x),
                         spawner.transform.position.y,
                         Random.Range(spawner.transform.position.z - spawner.transform.localScale.z, spawner.transform.position.z + spawner.transform.localScale.z));
                delayClock = 0;
            }
            if (spawnedBoxes >= topBoxes)
            {
                if (destroyedBoxes >= spawnedBoxes)
                {
                    GameOver();
                }
            }
        }
    }

    private void SpawnBox(float x, float y, float z)
    {
        Box boxInstance = Instantiate(box, new Vector3(x, y, z), Quaternion.identity).GetComponent<Box>();
        boxInstance.BoxKilled = BoxKilled;
        boxInstance.BoxDestroyed = BoxDestroyed;
        spawnedBoxes++;
    }

    private void BoxKilled()
    {
        destroyedBoxes++;
        GameManager.score += 100;
    }

    private void BoxDestroyed()
    {
        destroyedBoxes++;
        GameManager.score -= 75;
    }

    public void Menu()
    {
        gameManager.Menu();
    }

    public void GameOver()
    {
        gameManager.GameOver();
    }

    public void StartGame()
    {
        gameManager.Retry();
    }

    public void Exit()
    {
        gameManager.ExitGame();
    }
}