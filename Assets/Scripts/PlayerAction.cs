using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    public PlayerControl playerControl;
    private Renderer rend;
    public Score score;
    public GameController gameController;
    public AudioSource collectAudio;
    public AudioSource gameOverAudio;
    public AudioSource jumpAudio;
    public AudioSource winAudio;
    public AudioSource bonusAudio;
    private Animator anime;

    private void Start() {
        anime = GetComponent<Animator>();
        anime.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
       if (other.gameObject.tag == "Collectables") {
           score.AddScore(1);
           collectAudio.Play();
           Destroy(other.gameObject);
       }

       if (other.gameObject.tag == "BonusStart") {
            gameController.Bonus();
            bonusAudio.Play();
            Destroy(other.gameObject);
        }
   }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Obstacles") {
            gameController.GameOver();
            gameOverAudio.Play();
            playerControl.enabled = false;
        }

        if (other.gameObject.tag == "Finish") {
            winAudio.Play();
            gameController.GameOver();
            playerControl.enabled = false;
            anime.enabled = true;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) {
            jumpAudio.Play();
        }
    }
}   