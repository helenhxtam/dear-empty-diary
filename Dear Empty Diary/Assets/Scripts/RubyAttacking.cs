﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyAttacking : MonoBehaviour
{
    Animator animator;

    private bool attacking;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetBool("attacking", attacking);

        if (Input.GetKeyDown(KeyCode.M))
        {
            attacking = true;
        }

        if (!Input.GetKey(KeyCode.M))
        {
            attacking = false;
        }
    }

    void ToggleWeaponCollider()
    {
        GameObject.Find("WeaponCollider").GetComponent<BoxCollider2D>().enabled = attacking ? true : false;
    }
}