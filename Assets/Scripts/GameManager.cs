using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] GameObject GameOverUI;
    public bool playerDied;
    private void Awake() {
        instance = this;
        playerDied = false;
    }


    public void GameOver() {
        playerDied = true;
        GameOverUI.SetActive(true);
        GameOverUI.GetComponent<Fade>().In(2);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu() {

    }



}
