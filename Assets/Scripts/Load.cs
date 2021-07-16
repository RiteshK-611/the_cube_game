using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    [SerializeField] private GameObject progressPanel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private Text progressValue;

    public void Awake() 
    {
        progressPanel.SetActive(false);
    }

    public void LoadGame()
    {
        progressPanel.SetActive(true);
        StartCoroutine(LoadGameAsync());
    }

    private IEnumerator LoadGameAsync()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("Game");

        while(!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress);

            progressBar.value = progress;
            progressValue.text = "Loading " + (progress * 100f).ToString("F0") + "%";
            // loadingText.text = "LOADING " + Mathf.Round(progressValue * 100) + "%";
            yield return null;
        }
    }
}