using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantSound : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
