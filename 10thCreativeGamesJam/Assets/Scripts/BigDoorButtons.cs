using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BigDoorButtons : MonoBehaviour
{
    public GameObject BigDoor;
    public TMP_Text viewText;
    public Camera playerCam;
    public Camera doorCam;

    private Animator animDoor;
    private GameObject player;
    private bool canPush = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animDoor = BigDoor.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PushButton();
    }

    private void PushButton () {
        if (canPush && Input.GetKeyDown(KeyCode.E)) {
            animDoor.SetTrigger("Open");
            viewText.text = "";
            SwitchCameras();
        }
    }

    public void SwitchCameras() {
        if(playerCam.enabled) {
            playerCam.enabled = false;
            doorCam.enabled = true;
            player.GetComponent<PlayerMovement>().enabled = false;
        } else if (doorCam.enabled) {
            playerCam.enabled = true;
            doorCam.enabled = false;
            player.GetComponent<PlayerMovement>().enabled = true;
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
