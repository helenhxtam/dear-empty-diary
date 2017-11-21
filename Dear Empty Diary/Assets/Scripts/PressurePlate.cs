﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    [Tooltip("The door that is connected to this object's switch.")]
    public GameObject door;
    [Tooltip("The sprite that a closed door has.")]
    public Sprite closedDoor;
    [Tooltip("The sprite that an open door has.")]
    public Sprite openDoor;

    // When Ruby triggers the lever, activate the door (swap sprites)
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "PushableBox") {
            // Disable the box collider on this lever (it was used already)
            this.GetComponent<BoxCollider2D>().enabled = false;
            // Swap the door's sprite to the open one
            door.GetComponent<SpriteRenderer>().sprite = openDoor;
            // And finally enable its polygon collider
            door.GetComponent<PolygonCollider2D>().enabled = true;

            // Trigger Dialog
            this.GetComponent<TextScript>().TriggerDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        this.GetComponent<BoxCollider2D>().enabled = true;
        door.GetComponent<SpriteRenderer>().sprite = closedDoor;
        door.GetComponent<PolygonCollider2D>().enabled = false;
    }
}