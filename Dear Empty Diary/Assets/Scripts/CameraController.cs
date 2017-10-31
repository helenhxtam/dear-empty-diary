using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    const float ROOM_SIZE_PAN = 13.25f;

    public void MoveCamera(string doorName) {
        if (doorName == "Right Door") {
            Vector3 newPos = this.transform.position;
            newPos.x += ROOM_SIZE_PAN;
            this.transform.position = newPos;
        }
        else if (doorName == "Left Door") {
            Vector3 newPos = this.transform.position;
            newPos.x -= ROOM_SIZE_PAN;
            this.transform.position = newPos;
        }
    }
}
