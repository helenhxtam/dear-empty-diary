using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyWalk : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        movement();

	}

    void movement()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector2.right * 2 * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * 2 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * 2 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector2.up * 2 * Time.deltaTime);
        }

    }
}
