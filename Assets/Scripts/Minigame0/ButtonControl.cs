using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonControl : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnButtonClick()
    {
        //Debug.Log(this.gameObject.name);
        if (String.Compare(this.gameObject.name, "Button0") == 0)
        {
            GameObject.Find("GameManager").GetComponent<MainEventManager>().button0 = true;
        }
        else if (String.Compare(this.gameObject.name, "Button1") == 0)
        {
            GameObject.Find("GameManager").GetComponent<MainEventManager>().button1 = true;
        }
        else if (String.Compare(this.gameObject.name, "Button2") == 0)
        {
            GameObject.Find("GameManager").GetComponent<MainEventManager>().button2 = true;
        }
        return;
    }
}
