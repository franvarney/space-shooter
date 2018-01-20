using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    private GameController gameController;
    public GameObject playerExplosion;
    public int score;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Boundary") {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(score);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    private void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameController == null) {

        }
    }
}
