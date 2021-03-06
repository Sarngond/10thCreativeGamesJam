﻿using System.Collections;
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
    private bool canSwitch = false;
    //private bool doorOpened = false;
    //private bool canDoorCam = false;

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
            SwitchToMill();
            //canDoorCam = true;
            //SwitchCameras();
            //Invoke("OpenDoor", 4f);
        }
    }

    private void SwitchToMill() {
        millCam.enabled = true;
        playerCam.enabled = false;

        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponentInChildren<CameraController>().enabled = false;

        Invoke("SwitchToDoor", 4f);
    }

    private void SwitchToDoor() {
        animDoor.SetTrigger("Open");
        doorCam.enabled = true;
        millCam.enabled = false;
        
        Invoke("SwitchToPlayer", 3f);
    }

    private void SwitchToPlayer() {
        playerCam.enabled = true;
        doorCam.enabled = false;

        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponentInChildren<CameraController>().enabled = true;
    }

    /*public void SwitchCameras() {
        if (playerCam.enabled) {
            SwitchToMill();
        }
        if (millCam.enabled || doorCam.enabled) {
            SwitchToPlayer();
        }
    }

    public void SwitchToMill() {
        if (canDoorCam) {
        Debug.Log("Player2Other");
            millCam.enabled = true;
            playerCam.enabled = false;
            doorCam.enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponentInChildren<CameraController>().enabled = false;
        }
    }

    public void SwitchToPlayer() {
        Debug.Log("Other2Player");
        canDoorCam = false;
        playerCam.enabled = true;
        millCam.enabled = false;
        doorCam.enabled = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponentInChildren<CameraController>().enabled = true;
    }

    public void OpenDoor() {
        if (!doorOpened) {
            if (canDoorCam) {
                animDoor.SetTrigger("Open");
                doorOpened = true;
                doorCam.enabled = true;
                playerCam.enabled = false;
                millCam.enabled = false;
            } else {
                animDoor.SetTrigger("Open");
                doorOpened = true;
                doorCam.enabled = false;
                playerCam.enabled = true;
                millCam.enabled = false;
            }
        }
    }*/

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
