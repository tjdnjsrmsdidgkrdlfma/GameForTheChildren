using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardControl : MonoBehaviour
{
    public float rotatespeed = 0.001f;
    float rotatevalue = 0;
    bool isclicked = false;
    bool isrotating = false;

    GameManager_3 gamemanager;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager_3>();
    }

    void Update()
    {
        if (isclicked == true && isrotating == false && (gamemanager.isfliped0 == false || gamemanager.isfliped1 == false))
        {
            StartCoroutine(RotateCard());
        }
    }

    IEnumerator RotateCard()
    {
        isrotating = true;
        rotatevalue = 0;
        while (rotatevalue >= 0 && rotatevalue <= 180)
        {
            rotatevalue += rotatespeed * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, 0, rotatevalue);
            yield return null;
        }
        this.transform.rotation = Quaternion.Euler(0, 0, 180);
        SetGamemanagerValue();
        isclicked = false;
        this.GetComponent<CardControl>().enabled = false;
    }

    void SetGamemanagerValue()
    {
        if (gamemanager.isfliped0 == false)
        {
            gamemanager.isfliped0 = true;
        }
        else if (gamemanager.isfliped1 == false)
        {
            gamemanager.isfliped1 = true;
        }

        if (gamemanager.flipedcard0 == 0)
        {
            gamemanager.flipedcard0 = Convert.ToInt32(this.gameObject.name.Substring(6, 1));
        }
        else if (gamemanager.flipedcard1 == 0)
        {
            gamemanager.flipedcard1 = Convert.ToInt32(this.gameObject.name.Substring(6, 1));
        }

        return;
    }

    void OnMouseDown()
    {
        isclicked = true;
    }
}