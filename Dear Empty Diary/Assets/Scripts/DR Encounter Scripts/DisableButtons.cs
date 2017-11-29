using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButtons : MonoBehaviour {

    // The buttons on the canvas to disable/enable
    [SerializeField]
    private GameObject goodBtn;
    [SerializeField]
    private GameObject badBtn;

    void Start()
    {
        if (!goodBtn)
        {
            goodBtn = GameObject.Find("GoodBtn");
        }

        if (!badBtn)
        {
            badBtn = GameObject.Find("BadBtn");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        ToggleButtons();
    }

    void OnTriggerExit2D()
    {
        ToggleButtons();
    }

    public void ToggleButtons()
    {
        this.goodBtn.gameObject.SetActive(!this.goodBtn.activeSelf);
        this.badBtn.gameObject.SetActive(!this.badBtn.activeSelf);
    }
}
