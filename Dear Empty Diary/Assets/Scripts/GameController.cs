using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameObject gameCamera;

    void Start()
    {
        gameCamera = GameObject.Find("Game Camera");
    }
}
