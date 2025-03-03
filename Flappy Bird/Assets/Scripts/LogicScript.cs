using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOver;
    public int playerScore;
    public Text score;

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd){
        playerScore += scoreToAdd;
        score.text = playerScore.ToString();
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver(){
        gameOver.SetActive(true);
    }
}
