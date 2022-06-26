using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_4 : MonoBehaviour
{
    public int numberofcorrect;

    void Start()
    {
        numberofcorrect = 0;
        PutMaterial();
    }

    void Update()
    {
        if (CheckPuzzle())
        {
            Debug.Log("Correct");
        }
    }

    void PutMaterial()
    {
        int i;
        int[] random = new int[3];

        SwipeRandom(random);

        for (i = 0; i < 3; i++)
        {
            GameObject.Find("Place (" + i + ")").GetComponent<MeshRenderer>().material = Resources.Load("Minigame4/Materials/0_" + random[i]) as Material;
        }

        SwipeRandom(random);

        for (i = 0; i < 3; i++)
        {
            GameObject.Find("Piece (" + i + ")").GetComponent<MeshRenderer>().material = Resources.Load("Minigame4/Materials/1_" + random[i]) as Material;
        }

        return;
    }

    void SwipeRandom(int[] random)
    {
        random[0] = UnityEngine.Random.Range(0, 3);
        do
        {
            random[1] = UnityEngine.Random.Range(0, 3);
        } while (random[1] == random[0]);
        do
        {
            random[2] = UnityEngine.Random.Range(0, 3);
        } while (random[2] == random[0] || random[2] == random[1]);

        return;
    }

    bool CheckPuzzle()
    {
        if (numberofcorrect == 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
