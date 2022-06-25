using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControlButton : MonoBehaviour
{
    GameObject Object;
    int movespeed;
    bool ismoving = false;

    void Start()
    {
        Object = GameObject.Find("Buttons");
        movespeed = 50;
    }

    void Update()
    {

    }

    public void LeftButton()
    {
        StartCoroutine(MoveToLeft());

        return;
    }

    IEnumerator MoveToLeft()
    {
        int firstx = Convert.ToInt32(Object.GetComponent<RectTransform>().anchoredPosition.x);
        int realx = Convert.ToInt32(Object.GetComponent<RectTransform>().anchoredPosition.x);

        if (firstx <= -7200 || ismoving == true)
        {
            yield break;
        }

        ismoving = true;

        while (true)
        {
            realx -= movespeed;
            Object.GetComponent<RectTransform>().anchoredPosition = new Vector3(realx, 0);
            yield return null;
            if (realx - firstx <= -2400)
            {
                break;
            }
        }

        Object.GetComponent<RectTransform>().anchoredPosition = new Vector3(firstx - 2400, 0);
        ismoving = false;
        yield break;
    }

    public void RightButton()
    {
        StartCoroutine(MoveToRight());

        return;
    }

    IEnumerator MoveToRight()
    {
        int firstx = Convert.ToInt32(Object.GetComponent<RectTransform>().anchoredPosition.x);
        int realx = Convert.ToInt32(Object.GetComponent<RectTransform>().anchoredPosition.x);

        if (firstx >= 0 || ismoving == true)
        {
            yield break;
        }

        ismoving = true;

        while (true)
        {
            realx += movespeed;
            Object.GetComponent<RectTransform>().anchoredPosition = new Vector3(realx, 0);
            yield return null;
            if (firstx - realx <= -2400)
            {
                break;
            }
        }

        Object.GetComponent<RectTransform>().anchoredPosition = new Vector3(firstx + 2400, 0);
        ismoving = false;
        yield break;
    }
}
