using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject bonusPanel;
    public GameObject tapToStart;
    public GameObject scoreText;
    private float _time = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        bonusPanel.SetActive(false);
        PauseGame();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartGame();
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            PauseGame();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        scoreText.SetActive(false);
        Cursor.visible = true;
    }

    public void Restart() {
        SceneManager.LoadScene("Game");
        Cursor.visible = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        tapToStart.SetActive(true);
        Cursor.visible = true;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        scoreText.SetActive(true);
        tapToStart.SetActive(false);
        Cursor.visible = false;
    }

    public void Bonus()
    {
        bonusPanel.SetActive(true);
        Invoke("SetFalse", _time);
    }

    public void SetFalse() {
        bonusPanel.SetActive(false);
    }
}
