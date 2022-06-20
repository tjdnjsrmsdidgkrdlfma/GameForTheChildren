using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardControl : MonoBehaviour
{
    public float rotatespeed = 0.001f;
    float rotatevalue = 0;
    bool isclicked = false;
    public bool isrotating = false;

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
        SetGamemanagerValue();
        isrotating = true;
        rotatevalue = 0;
        while (rotatevalue >= 0 && rotatevalue <= 180)
        {
            rotatevalue += rotatespeed * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, 0, rotatevalue);
            yield return null;
        }
        this.transform.rotation = Quaternion.Euler(0, 0, 180);
        isclicked = false;
        isrotating = false;
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

        if (gamemanager.flipedcard0 == -1) //�� �ڸ� ���� ��쵵 ��� ���� ������ GetNumber�Լ� ���� ��򰡿�
        {

            gamemanager.flipedcard0 = GetNumber(this.gameObject.name.Substring(6, 2).ToString());
        }
        else if (gamemanager.flipedcard1 == -1)
        {
            gamemanager.flipedcard1 = GetNumber(this.gameObject.name.Substring(6, 2).ToString());
        }

        return;
    }

    int GetNumber(string temp)
    {
        int result;

        if (temp[1] == ')')
        {
            result = temp[0] - 0x30;
        }
        else
        {
            result = ((temp[0] - 0x30) * 10) + (temp[1] - 0x30);
        }

        return result;
    }

    void OnMouseDown()
    {
        isclicked = true;
    }
}