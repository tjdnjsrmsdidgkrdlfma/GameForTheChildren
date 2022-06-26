using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonControl_5 : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnButtonClick()
    {
        GameObject.Find("GameManager").GetComponent<GameManager_5>().choose = Convert.ToInt32(this.gameObject.name.Substring(12, 1));
    }
}
