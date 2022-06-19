using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager_1 : MonoBehaviour
{
    public bool[] PuzzleState = new bool[16];
    public int random;
    int numberofimages = 2;

    void Start()
    {
        random = UnityEngine.Random.Range(0, numberofimages);
        PuzzleState = Enumerable.Repeat(false, 16).ToArray();
        GameObject.Find("Background").GetComponent<MeshRenderer>().material = Resources.Load("Minigame1/Materials/Background") as Material;
        SetPlaces();
        PutMaterial();
    }

    void Update()
    {
        if (CheckPuzzle())
        {
            Debug.Log("Correct");
        }
    }

    void SetPlaces()
    {
        int i, j;
        bool change = true;
        string aa;

        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                if (j % 2 == 0)
                {
                    if (change)
                        aa = "Even";
                    else
                        aa = "Odd";
                }
                else
                {
                    if (change)
                        aa = "Odd";
                    else
                        aa = "Even";
                }
                GameObject.Find("PuzzlePlace (" + ((i * 4) + j) + ")").GetComponent<MeshRenderer>().material = Resources.Load("Minigame1/Materials/Place_" + aa) as Material;
            }
            change = change ? false : true;
        }

        return;
    }

    void PutMaterial()
    {
        int i;

        for (i = 0; i < 16; i++)
        {
            GameObject.Find("PuzzlePiece (" + i + ")").GetComponent<MeshRenderer>().material = Resources.Load("Minigame1/Materials/Piece" + random + "_" + i) as Material;
        }

        return;
    }

    bool CheckPuzzle()
    {
        if (!PuzzleState.Contains(false))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}