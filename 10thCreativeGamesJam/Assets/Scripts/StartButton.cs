using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public Camera playerCam;
    public Camera buttonCam;
    public GameObject buttonUI;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SwitchCameras() {
        if (playerCam.enabled) {
            playerCam.enabled = false;
            buttonCam.enabled = true;
            buttonUI.SetActive(true);
        }
        else if (buttonCam.enabled) {
            playerCam.enabled = true;
            buttonCam.enabled = false;
            buttonUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider == player.GetComponent<Collider>()) {
            SwitchCameras();
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (collider == player.GetComponent<Collider>()) {
            SwitchCameras();
        }
    }
}
