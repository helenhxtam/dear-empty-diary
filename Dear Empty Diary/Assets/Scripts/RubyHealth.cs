﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if(GameObject.FindGameObjectWithTag("Persistant") != null)
        {
            health = GameObject.FindGameObjectWithTag("Persistant").GetComponent<PersistantValues>().health;
        }
        else
        {
            health = 4;
        }
        updateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Persistant") != null)
        {
            health = GameObject.FindGameObjectWithTag("Persistant").GetComponent<PersistantValues>().health;
        }
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
        if(!isDamaged)
        {
            if (GameObject.FindGameObjectWithTag("Persistant") != null)
            {
                GameObject.FindGameObjectWithTag("Persistant").GetComponent<PersistantValues>().decrementHealth();
            }
            else
            {
                health--;
            }     
            updateHealth();
            isDamaged = true;
        }
    }

    void updateHealth()
    {
        if(GameObject.FindGameObjectWithTag("Persistant") != null)
        {
            health = GameObject.FindGameObjectWithTag("Persistant").GetComponent<PersistantValues>().health;
        }
        Image healthImage = healthUI.GetComponent<Image>();
        switch (health)
        {
            case 0:
                healthImage.sprite = heartSprites[0];
                SceneManager.LoadScene(0);
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
                color.a = 0.1f;
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }

    void TimeEnd()
    {
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a = 1.0f;
        gameObject.GetComponent<SpriteRenderer>().color = color;
        isDamaged = false;
        timer = 2.0f;
    }
}