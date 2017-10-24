using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    const float ROOM_SIZE_PAN = 13.25f;

	// On Button Press - Move Camera Pan
    void FixedUpdate()
    {
    //    if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < ROOM_SIZE_PAN)
    //    {
    //        Vector3 newPos = this.transform.position;
    //        newPos.x = ROOM_SIZE_PAN;
    //        this.transform.position = newPos;
    //    }
    //    else if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > 0.0f)
    //    {
    //        Vector3 newPos = this.transform.position;
    //        newPos.x = 0;
    //        this.transform.position = newPos;
    //    }
    }
}
