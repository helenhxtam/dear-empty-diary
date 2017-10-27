﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyWalk : MonoBehaviour {

    [Tooltip("Defines whether or not Ruby is currently moving.")]
    public bool isMoving;

    // The direction she's facing
    private Vector2 direction;

	// FixedUpdate is called once per frame
	void FixedUpdate () {
        if (!isMoving)
        {
            return;
        }
        Movement();
	}

    // Keyboard controls to move Ruby
    void Movement()
    {
        if (!this.GetComponent<RubyShooting>().isShooting())
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-Vector2.right * 2 * Time.deltaTime);
                direction = -Vector2.right;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * 2 * Time.deltaTime);
                direction = Vector2.right;
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * 2 * Time.deltaTime);
                direction = Vector2.up;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-Vector2.up * 2 * Time.deltaTime);
                direction = -Vector2.up;
            }
        }
    }

    // Moves Ruby depending on which door she takes
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Right Door")
        {
            GameController.gameCamera.GetComponent<CameraController>().MoveCamera("Right Door");
            this.transform.position = col.gameObject.transform.Find("Spawn Location").transform.position;
        }
        else if (col.gameObject.tag == "Left Door")
        {
            GameController.gameCamera.GetComponent<CameraController>().MoveCamera("Left Door");
            this.transform.position = col.gameObject.transform.Find("Spawn Location").transform.position;
        }
    }

    // Returns the direction Ruby's facing
    public Vector2 GetDirection()
    {
        return direction;
    }
}
