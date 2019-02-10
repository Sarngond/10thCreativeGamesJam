using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuButtons : MonoBehaviour
{
    public TMP_Text viewText;
    public Camera playerCam;
    public Camera buttonCam;
    public GameObject buttonUI;
    public string textMessage;

    private Animator animDoor;
    private GameObject player;
    private bool canPush = false;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        PushButton();
    }

    private void PushButton() {
        if (canPush && Input.GetKeyDown(KeyCode.E)) {
            viewText.text = "";
            SwitchCameras();
        }
    }

    public void SwitchCameras() {
        if (playerCam.enabled) {
            playerCam.enabled = false;
            buttonCam.enabled = true;
            buttonUI.SetActive(true);

            player.GetComponent<PlayerAttack>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Animator>().SetBool("isWalking", false);
            playerCam.GetComponent<CameraController>().enabled = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (buttonCam.enabled) {
            playerCam.enabled = true;
            buttonCam.enabled = false;
            buttonUI.SetActive(false);

            player.GetComponent<PlayerAttack>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;
            playerCam.GetComponent<CameraController>().enabled = true;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider == player.GetComponent<Collider>()) {
            canPush = true;
            viewText.text = textMessage;
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (collider == player.GetComponent<Collider>()) {
            canPush = false;
            viewText.text = "";
        }
    }
}
