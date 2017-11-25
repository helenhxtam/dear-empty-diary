using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcquirePage : MonoBehaviour {

    private int maxLevel, currentLevel;

    void Start() {
        maxLevel = SceneManager.sceneCountInBuildSettings - 1;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

	// When Ruby hits a Page with her melee attack, save the game
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Melee") {
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);

            Debug.Log("Saved Game");

            if (currentLevel + 1 <= maxLevel) {
                SceneManager.LoadScene(currentLevel + 1);
            }
            else {
                Debug.Log("You finished the game!");
                SceneManager.LoadScene(0);
            }
        }
	}
}
