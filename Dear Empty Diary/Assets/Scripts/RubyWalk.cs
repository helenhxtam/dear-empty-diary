using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyWalk : MonoBehaviour {
    // The direction she's facing
    private Vector2 direction;

    //animator for characters movement
    Animator animator;

    //booleans to switch state of animator
    [SerializeField]
    bool isMoving;
    [SerializeField]
    bool isForward;
    [SerializeField]
    bool isBack;
    [SerializeField]
    bool isLeft;
    [SerializeField]
    bool isRight;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate () {
        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            isMoving = false;
            
        }
        Movement();

        animator.SetBool("forward", isForward);
        animator.SetBool("back", isBack);
        animator.SetBool("left", isLeft);
        animator.SetBool("right", isRight);
        animator.SetBool("moving", isMoving);
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
                isForward = false;
                isBack = false;
                isLeft = true;
                isRight = false;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * 2 * Time.deltaTime);
                direction = Vector2.right;
                isForward = false;
                isBack = false;
                isLeft = false;
                isRight = true;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * 2 * Time.deltaTime);
                direction = Vector2.up;
                isForward = false;
                isBack = true;
                isLeft = false;
                isRight = false;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-Vector2.up * 2 * Time.deltaTime);
                direction = -Vector2.up;
                isForward = true;
                isBack = false;
                isLeft = false;
                isRight = false;
                isMoving = true;
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
