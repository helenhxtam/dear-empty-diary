using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcquirePage : MonoBehaviour {

    // Maximum loadable level, and current level
    private int maxLevel, currentLevel;

    // Sets up the maxLevel and currentLevel
    void Start() {
        maxLevel = SceneManager.sceneCountInBuildSettings - 1;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

	// When Ruby hits a Page with her melee attack, save the game
    // TODO: Remove this
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

    // Loads next level after acquiring the diary page
    public void AcquireDiary()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        
        Debug.Log("Saved Game");

        if (currentLevel + 1 <= maxLevel)
        {
            SceneManager.LoadScene(currentLevel + 1);
        }
        else
        {
            Debug.Log("You finished the game!");
            SceneManager.LoadScene(0);
        }
    }
}

