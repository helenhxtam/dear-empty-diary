using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitches : MonoBehaviour {

    [Tooltip("The door that is connected to this object's switch.")]
    public GameObject attachedObject;

    private bool isActivated;

    // When Ruby triggers the lever, activate the door (swap sprites)
    void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.name == "Projectile(Clone)" || col.gameObject.name == "Bat") {

            if(attachedObject.tag == "Left Door" || attachedObject.tag == "Right Door" || attachedObject.tag == "Top Door" || attachedObject.tag == "Bottom Door") {
                attachedObject.GetComponent<DoorManager>().toggleDoor();
                flipLever();
                isActivated = !isActivated;
            }



            //if (!isActivated) {
            //    // Mark switch as activated
            //    isActivated = true;
            //    // Change Sprite of the door 
            //    door.GetComponent<SpriteRenderer>().sprite = openDoor;
            //    // Enable door's polygon collider
            //    door.GetComponent<PolygonCollider2D>().enabled = true;
            //    // Flip the switch
            //    this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            //    // Trigger Dialog 
            //    // this.GetComponent<TextScript>().TriggerDialogue();
            //}

            //else {
            //    // Mark switch as disactivated
            //    isActivated = false;
            //    // Change Sprite of the Door
            //    door.GetComponent<SpriteRenderer>().sprite = closedDoor;
            //    // Disable door's polygon collider
            //    door.GetComponent<PolygonCollider2D>().enabled = false;
            //    // Flip the switch
            //    this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            //    // Trigger Dialog 
            //    // this.GetComponent<TextScript>().TriggerDialogue();
            //}
        }
    }

    
    private void flipLever() {
        this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
    }
 }
