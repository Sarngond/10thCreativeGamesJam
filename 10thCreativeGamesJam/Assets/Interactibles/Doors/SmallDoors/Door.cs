using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    private bool canOpen = true;
    private bool nearDoor = false;

    private void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        OpenDoor();
    }

    private void OpenDoor () {
        if (nearDoor) {
            if (canOpen && Input.GetKeyDown(KeyCode.E)) {
                anim.SetTrigger("OpenDoor");
                canOpen = false;
            }
            else if (!canOpen && Input.GetKeyDown(KeyCode.E)) {
                anim.SetTrigger("CloseDoor");
                canOpen = true;
            }
        }
    }

    private void OnTriggerStay(Collider collider) {
        if (collider == player.GetComponent<Collider>()) {
            nearDoor = true;
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (collider == player.GetComponent<Collider>()) {
            nearDoor = false;
        }
    }
}
