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
        cardstate = Enumerable.Repeat(false, 16).ToArray();
        SetValue();
        SetCardImages();
    }

    void Update()
    {
        if (isfliped0 == true && isfliped1 == true)
        {
            DoSomething();
            CheckGameCorrect();
        }
    }

    void SetValue()
    {
        flipedcard0 = -1;
        flipedcard1 = -1;
        isfliped0 = false;
        isfliped1 = false;
        return;
    }

    void SetCardImages()
    {
        int i;
        int random;
        int[] temp = new int[8];

        for (i = 0; i < 8; i++)
        {
            temp[i] = 0;
        }

        for (i = 0; i < 16; i++)
        {
            do
            {
                random = UnityEngine.Random.Range(0, 8);
            } while (temp[random] >= 2);
            GameObject.Find("Card (" + i + ")").transform.Find("Back").GetComponent<MeshRenderer>().material = Resources.Load("Minigame3/Materials/" + random) as Material;
            temp[random]++;
        }

        return;
    }

    void DoSomething()
    {
        if (CheckCardCorrect() == true)
        {
            if (GameObject.Find("Card (" + flipedcard0 + ")").GetComponent<CardControl>().isrotating == false && GameObject.Find("Card (" + flipedcard1 + ")").GetComponent<CardControl>().isrotating == false)
            {
                Destroy(GameObject.Find("Card (" + flipedcard0 + ")").GetComponent<CardControl>());
                Destroy(GameObject.Find("Card (" + flipedcard1 + ")").GetComponent<CardControl>());
                cardstate[flipedcard0] = true;
                cardstate[flipedcard1] = true;
            }
        }
        else
        {
            GameObject.Find("Card (" + flipedcard0 + ")").GetComponent<CardControl>().enabled = true;
            GameObject.Find("Card (" + flipedcard1 + ")").GetComponent<CardControl>().enabled = true;
        }

        SetValue();

        return;
    }

    bool CheckCardCorrect()
    {
        int first, second;
        string first_, second_;
        first_ = Convert.ToString(GameObject.Find("Card (" + flipedcard0 + ")").transform.Find("Back").GetComponent<MeshRenderer>().material.name);
        second_ = Convert.ToString(GameObject.Find("Card (" + flipedcard1 + ")").transform.Find("Back").GetComponent<MeshRenderer>().material.name);

        first = first_[0] - '0';
        second = second_[0] - '0';

        Debug.Log(first + "_" + second);

        if (first == second)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void CheckGameCorrect()
    {
        if (!cardstate.Contains(false))
        {
            Debug.Log("GGWP");
        }
        return;
    }
}
