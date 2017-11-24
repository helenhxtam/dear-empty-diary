using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    [Tooltip("The object that is connected to this switch.")]
    public GameObject attachedObject;

    public bool isActivated;

    // When Pressure is applied to plate
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "PushableBox") {

            this.GetComponent<BoxCollider2D>().enabled = false;


            if (attachedObject.tag == "Left Door" || attachedObject.tag == "Right Door" || attachedObject.tag == "Top Door" || attachedObject.tag == "Bottom Door") {

                Debug.Log("PRINT");

                
                attachedObject.GetComponent<DoorManager>().toggleDoor();
                isActivated = !isActivated;
            }

            //// Disable the box collider on this lever (it was used already)
            //this.GetComponent<BoxCollider2D>().enabled = false;
            //// Swap the door's sprite to the open one
            //door.GetComponent<SpriteRenderer>().sprite = openDoor;
            //// And finally enable its polygon collider
            //door.GetComponent<PolygonCollider2D>().enabled = true;

            // Trigger Dialog
            // this.GetComponent<TextScript>().TriggerDialogue();
        }
    }

    // When Pressure is released from plate
    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "PushableBox") {

            if (attachedObject.tag == "Left Door" || attachedObject.tag == "Right Door" || attachedObject.tag == "Top Door" || attachedObject.tag == "Bottom Door") {
                // this.GetComponent<BoxCollider2D>().enabled = true;
                attachedObject.GetComponent<DoorManager>().toggleDoor();
                isActivated = !isActivated;
            }
        }
    }
}
