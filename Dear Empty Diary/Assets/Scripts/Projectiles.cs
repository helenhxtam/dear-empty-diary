using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // Finds all GameObjects in the scene with the tag Fence
        GameObject[] fences = GameObject.FindGameObjectsWithTag("Fence");

        // For each Fence, ignore collision with it
        foreach (GameObject obj in fences) {
            Physics2D.IgnoreCollision(obj.gameObject.GetComponent<BoxCollider2D>(), this.GetComponent<CircleCollider2D>(), true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag != "Ruby") {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Ruby")
        {
            Destroy(this.gameObject);
        }
        /*
        if (col.gameObject.tag == "Levers") {
            Destroy(this.gameObject);
        }*/
    }
}
