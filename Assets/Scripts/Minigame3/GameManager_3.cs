using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameManager_3 : MonoBehaviour
{
    public const int cardnumber = 16;
    public bool[] cardstate = new bool[cardnumber];

    public int flipedcard0;
    public int flipedcard1;
    public bool isfliped0;
    public bool isfliped1;

    void Start()
    {
        SetValue();
        SetCardImages();
    }

    void Update()
    {
        if (isfliped0 == true && isfliped1 == true)
        {
            DoSomething(CheckCorrect());
        }
    }

    void SetValue()
    {
        cardstate = Enumerable.Repeat(false, 16).ToArray();
        flipedcard0 = 0;
        flipedcard1 = 0;
        isfliped0 = false;
        isfliped1 = false;
        return;
    }

    void SetCardImages()
    {
        int i;
        int random = 0;
        int[] temp = new int[8];

        temp = Enumerable.Repeat(0, 8).ToArray();

        for (i = 0; i < 16; i++)
        {
            while (temp[random] >= 2)
            {
                random = UnityEngine.Random.Range(0, 8);
            }
            GameObject.Find("Card (" + i + ")").transform.Find("Back").GetComponent<MeshRenderer>().material = Resources.Load("Minigame3/Materials/" + random) as Material;
            temp[random]++;
        }

        return;
    }

    bool CheckCorrect()
    {
        int first, second;
        first = Convert.ToInt32(GameObject.Find("Card (" + flipedcard0 + ")").transform.Find("Back").GetComponent<MeshRenderer>().material);
        second = Convert.ToInt32(GameObject.Find("Card (" + flipedcard1 + ")").transform.Find("Back").GetComponent<MeshRenderer>().material);

        if (first == second)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void DoSomething(bool correct)
    {
        if (correct == true)
        {
            GameObject.Find("Card (" + flipedcard0 + ")").GetComponent<CardControl>().enabled = false;
            GameObject.Find("Card (" + flipedcard1 + ")").GetComponent<CardControl>().enabled = false;
            cardstate[flipedcard0] = true;
            cardstate[flipedcard1] = true;
        }
        else
        {

        }

        return;
    }
}
