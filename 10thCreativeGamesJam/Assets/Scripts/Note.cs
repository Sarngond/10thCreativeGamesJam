using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : MonoBehaviour
{
    public TMP_Text viewNoteText;
    public TMP_Text noteText;
    public string noteContext;

    private GameObject player;
    private bool canRead = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        Read();
    }

    private void Read () {
        if(canRead && Input.GetKeyDown(KeyCode.E)) {
            noteText.text = noteContext;
            viewNoteText.text = "";
            if(Input.GetButtonDown("Cancel")) {
                noteText.text = "";
            }
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider == player.GetComponent<Collider>()) {
            viewNoteText.text = "Read Note (E)";
            canRead = true;
        }
    }

    private void OnTriggerExit(Collider collider) {
        if (collider == player.GetComponent<Collider>()) {
            viewNoteText.text = "";
            canRead = false;
            noteText.text = "";
        }
    }
}
