using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

    private GameObject mainMenu, escMenu, confirmationWindow, errorWindow;

    private int maxLevel;

	void Start() {
        maxLevel = SceneManager.sceneCountInBuildSettings - 1;

        Time.timeScale = 1;

        mainMenu = GameObject.Find("Main Menu");
        escMenu = GameObject.Find("Escape Menu");
        confirmationWindow = GameObject.Find("Confirmation Window");
        errorWindow = GameObject.Find("Error Window");

        if (escMenu != null) {
            escMenu.SetActive(false);
        }

        if (confirmationWindow != null) {
            confirmationWindow.SetActive(false);
        }

        if (errorWindow != null) {
            errorWindow.SetActive(false);
        }
    }

    void FixedUpdate() {
        if (escMenu != null) {
            CheckEsc();
        }
    }

    public void ConfirmNewLevel(int level) {
        if (PlayerPrefs.GetInt("Level") > 0 && PlayerPrefs.GetInt("Level") < maxLevel) {
            mainMenu.SetActive(false);
            confirmationWindow.SetActive(true);
        }
        else {
            LoadLevel(level);
        }
    }

    public void LoadNextLevel() {
        int currentLevel = PlayerPrefs.GetInt("Level");

        if (currentLevel == 0 || currentLevel + 1 > maxLevel) {
            mainMenu.SetActive(false);
            errorWindow.SetActive(true);
        }

        else if (currentLevel + 1 <= maxLevel) {
			LoadLevel(currentLevel + 1);
		}
        //else {
        //    LoadLevel(1);
        //}
    }

    public void ExitApplication() {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Resume() {
        Time.timeScale = 1;
        escMenu.SetActive(false);
    }

    public void Restart(int level) {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);

        LoadLevel(1);
    }

    public void Cancel() {
        confirmationWindow.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OK() {
        errorWindow.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void LoadLevel(int level) {
        SceneManager.LoadScene(level);
    }

    private void CheckEsc() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Time.timeScale == 1) {
                Time.timeScale = 0;
                escMenu.SetActive(true);
            }
            else if (Time.timeScale == 0) {
                Time.timeScale = 1;
                escMenu.SetActive(false);
            }
        }
    }
}
