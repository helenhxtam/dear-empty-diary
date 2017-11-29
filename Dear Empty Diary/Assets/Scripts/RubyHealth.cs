﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyHealth : MonoBehaviour
{

    public int health;

    public Sprite[] heartSprites;

    public GameObject healthUI;

    private bool isDamaged;
    private float timer = 2.0f;

    // Use this for initialization
    void Start()
    {
        health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            TimeEnd();
        }
    }

    void takeDamage()
    {
        health--;
        updateHealth();
        isDamaged = true;
    }

    void updateHealth()
    {
        Image healthImage = healthUI.GetComponent<Image>();
        switch (health)
        {
            case 0:
                healthImage.sprite = heartSprites[0];
                Destroy(this.gameObject);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Trap" || col.gameObject.tag == "CannonProjectile")
        {
            takeDamage();
            if (isDamaged)
            {
                Color color = gameObject.GetComponent<SpriteRenderer>().color;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                color.a = 0.1f;
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }

    void TimeEnd()
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        color.a = 1.0f;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        isDamaged = false;
        timer = 2.0f;
    }
}
