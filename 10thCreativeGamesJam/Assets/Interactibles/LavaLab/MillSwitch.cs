using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MillSwitch : MonoBehaviour
{
    public GameObject MillWheel;
    public GameObject BigDoor;
    public TMP_Text viewText;
    public Camera playerCam;
    public Camera millCam;
    public Camera doorCam;

    private Animator animMill;
    private Animator animDoor;
    private GameObject player;
    private bool canPush = false;
    private bool doorOpened = false;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        animMill = MillWheel.GetComponent<Animator>();
        animDoor = BigDoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        PushButton();
    }

    private void PushButton() {
        if (canPush && Input.GetKeyDown(KeyCode.E)) {
            animMill.SetTrigger("MillOn");
            viewText.text = "";
            SwitchCameras();
            Invoke("OpenDoor", 4f);
        }
    }

    public void SwitchCameras() {
        if (playerCam.enabled) {
            playerCam.enabled = false;
            millCam.enabled = true;
            doorCam.enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponentInChildren<CameraController>().enabled = false;
        }
        else if (millCam.enabled || doorCam.enabled) {
            playerCam.enabled = true;
            millCam.enabled = false;
            doorCam.enabled = false;
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponentInChildren<CameraController>().enabled = true;
        }
    }

    public void OpenDoor() {
        if (!doorOpened) {
            animDoor.SetTrigger("Open");
            doorCam.enabled = true;
            playerCam.enabled = false;
            millCam.enabled = false;
            doorOpened = true;
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider == player.GetComponent<Collider>()) {
            canPush = true;
            viewText.text = "Push Button";
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (collider == player.GetComponent<Collider>()) {
            canPush = false;
            viewText.text = "";
        }
    }
}
