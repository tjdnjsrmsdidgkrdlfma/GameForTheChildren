//가장 큰 캐릭터에게 가장 많은 과일을 주는 게임

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
        SetX();
    }

    void Update()
    {
        if (CheckPuzzle())
        {
            this.gameObject.GetComponent<End>().EndMessage();
        }
    }

    void PutMaterial()
    {
        int i;
        int[] random = new int[3];

        SwipeRandom(random);

        for (i = 0; i < 3; i++)
        {
            GameObject.Find("Place (" + i + ")").GetComponent<MeshRenderer>().material = Resources.Load("Minigame4/Materials/Human") as Material;
        }

        SwipeRandom(random);

        for (i = 0; i < 3; i++)
        {
            GameObject.Find("Piece (" + i + ")").GetComponent<MeshRenderer>().material = Resources.Load("Minigame4/Materials/" + random[i]) as Material;
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

    void SetX()
    {
        int x = 0;
        int[] random = new int[3];
        int i;

        SwipeRandom(random);

        for (i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    x = -28;
                    break;
                case 1:
                    x = 0;
                    break;
                case 2:
                    x = 28;
                    break;

            }
            GameObject.Find("Place (" + random[i] + ")").transform.position = new Vector3(x, 0.1f, -10);
        }

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
