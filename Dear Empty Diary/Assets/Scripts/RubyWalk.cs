using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyWalk : MonoBehaviour {
    // The direction she's facing
    private Vector2 direction;

    // Animator for characters movement
    private Animator animator;

    // Booleans to switch state of animator
    private bool isMoving, isForward, isBack, isLeft, isRight;
    private float speed = 2.0f;

    void Start() {
        animator = GetComponent<Animator>();

        direction = Vector2.down;
        isForward = true;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate () {
        Movement();

        animator.SetBool("forward", isForward);
        animator.SetBool("back", isBack);
        animator.SetBool("left", isLeft);
        animator.SetBool("right", isRight);
        animator.SetBool("moving", isMoving);
    }

    // Keyboard controls to move Ruby
    void Movement() {
        Vector2 aDir = Vector2.zero;

        // Get direction of movement
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");

        isMoving = xDir != 0 || yDir != 0;

        aDir.x = xDir;
        aDir.y = yDir;

        if (!this.GetComponent<RubyAttacking>().IsAttacking()) {
            if (aDir.x != 0) {
                direction = new Vector2(aDir.x, 0);
                transform.Translate(direction * speed * Time.deltaTime);

                isRight = aDir.x > 0 ? true : false;
                isLeft = !isRight;
                isForward = isBack = false;
            }

            else if (aDir.y != 0) {
                direction = new Vector2(0, aDir.y);
                transform.Translate(new Vector2(0, aDir.y) * speed * Time.deltaTime);

                isForward = aDir.y > 0 ? false : true;
                isBack = !isForward;
                isRight = isLeft = false;
            }
        }
    }

    // Moves Ruby depending on which door she takes
    void OnTriggerEnter2D(Collider2D col) {

        // Move Ruby to the Right
        if (col.gameObject.tag == "Right Door")
        {
            GameController.gameCamera.GetComponent<CameraController>().MoveCamera("Right Door");
            this.transform.position = col.gameObject.transform.Find("Spawn Location").transform.position;
        }

        // Move Ruby to the Left
        else if (col.gameObject.tag == "Left Door")
        {
            GameController.gameCamera.GetComponent<CameraController>().MoveCamera("Left Door");
            this.transform.position = col.gameObject.transform.Find("Spawn Location").transform.position;
        }

        // Move Ruby to the Top
        else if (col.gameObject.tag == "Top Door")
        {
            GameController.gameCamera.GetComponent<CameraController>().MoveCamera("Top Door");
            this.transform.position = col.gameObject.transform.Find("Spawn Location").transform.position;
        }

        // Move Ruby to the Bottom
        else if (col.gameObject.tag == "Bottom Door")
        {
            GameController.gameCamera.GetComponent<CameraController>().MoveCamera("Bottom Door");
            this.transform.position = col.gameObject.transform.Find("Spawn Location").transform.position;
        }
    }

    // Returns the direction Ruby's facing
    public Vector2 GetDirection() {
        return direction;
    }
}
