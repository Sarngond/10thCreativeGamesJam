using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    //public Camera playerCam;
    //public Camera buttonCam;
    //public GameObject optionsUI;

    //private GameObject player;

    private void Start() {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LoadLevel (int buildIndex) {
		Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(buildIndex);
	}

	public void QuitRequest () {
		Debug.Log("I Want To Quit");
		Application.Quit();
	}

    public void BackButton () {
        //player.GetComponent<PlayerMovement>().enabled = true;
        //playerCam.GetComponent<CameraController>().enabled = true;

        //playerCam.enabled = true;
        //buttonCam.enabled = false;
        //optionsUI.SetActive(false);

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
