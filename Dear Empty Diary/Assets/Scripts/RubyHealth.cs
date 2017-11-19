using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyHealth : MonoBehaviour {

    public int health;

    public Sprite[] heartSprites;

    public GameObject healthUI;

	// Use this for initialization
	void Start () {
        health = 4;
	}
	
	// Update is called once per frame
	void Update () {
        


		if(Input.GetKeyDown("h"))
        {
            takeDamage();
        }
	}

    void takeDamage()
    {
        health--;
        updateHealth();
    }

    void updateHealth()
    {
        Image healthImage = healthUI.GetComponent<Image>();
        switch (health)
        {
            case 0:
                healthImage.sprite = heartSprites[0];
                break;
            case 1:
                healthImage.sprite = heartSprites[1];
                break;
            case 2:
                healthImage.sprite = heartSprites[2];
                break;
            case 3:
                healthImage.sprite = heartSprites[3];
                break;
            case 4:
                healthImage.sprite = heartSprites[4];
                break;
            default:
                healthImage.sprite = heartSprites[0];
                break;
        }
    }
}
