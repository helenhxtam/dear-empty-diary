using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantValues : MonoBehaviour {

    public int health;
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        health = 4;
    }

    public void decrementHealth()
    {
        health--;
    }
}
