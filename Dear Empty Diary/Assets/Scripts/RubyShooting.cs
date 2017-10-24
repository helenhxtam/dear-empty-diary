using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyShooting : MonoBehaviour {

    [Tooltip("The prefab for the projectile.")]
    public GameObject projectilePrefab;

    private bool shooting;
    private double speed = 10.0f;
    private GameObject projectile;
    private Vector3 position;
    private Vector2 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        position = this.transform.position;

        direction = this.GetComponent<RubyWalk>().GetDirection();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shooting = true;
            Shoot();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            shooting = false;
        }
	}

    private void Shoot()
    {
        Vector2 aDir = Vector2.zero;

        // Get direction of movement
        float dir = Input.GetAxisRaw("Horizontal");

        aDir.y = 0;
        aDir.x = dir;

        if (direction == Vector2.right)
            position.x += 0.5f;
        else if (direction == -Vector2.right)
            position.x -= 0.5f;
        else if (direction == Vector2.up)
            position.y += 0.5f;
        else
            position.y -= 0.5f;

        projectile = GameObject.Instantiate(projectilePrefab, position, Quaternion.identity);

        // try to use facing direction
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 10.0f;
        projectile.transform.parent = this.transform;
    }

    public bool isShooting() { return shooting; }
}
