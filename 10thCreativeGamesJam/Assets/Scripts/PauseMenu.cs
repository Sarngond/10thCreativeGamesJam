using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume () {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        player.GetComponentInChildren<CameraController>().enabled = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        player.GetComponentInChildren<CameraController>().enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadLevel(int buildIndex) {
        Time.timeScale = 1f;
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(buildIndex);
    }

    public void QuitRequest() {
        Debug.Log("I Want To Quit");
        Application.Quit();
    }
}
