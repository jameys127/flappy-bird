using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOver;
    public int playerScore;
    public Text score;
    public GameObject pipeSpawner;

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd){
        playerScore += scoreToAdd;
        score.text = playerScore.ToString();
        if(playerScore % 5 == 0){
            var pipes = GameObject.FindGameObjectsWithTag("Pipe");
            foreach(var pipe in pipes){
                pipe.GetComponent<PipeMoveScript>().IncreaseSpeed(1);
            }
            pipeSpawner.GetComponent<PipeSpawnScript>().IncreaseSpeedCounter();
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver(){
        pipeSpawner.GetComponent<PipeSpawnScript>().BirdDied();
        var pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach(var pipe in pipes){
            pipe.GetComponent<PipeMoveScript>().StopMoving();
        }
        gameOver.SetActive(true);
    }
}
