using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager_1 : MonoBehaviour
{
    public bool[] PuzzleState = new bool[16];
    public int random;
    int numberofimages = 3;

    void Start()
    {
        random = UnityEngine.Random.Range(0, numberofimages);
        PuzzleState = Enumerable.Repeat(false, 16).ToArray();
        //GameObject.Find("Background").GetComponent<MeshRenderer>().material = Resources.Load("Minigame1/Materials/Background") as Material;
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
        int i;

        for (i = 0; i < 16; i++)
        {
            GameObject.Find("PuzzlePlace (" + i + ")").GetComponent<MeshRenderer>().material = Resources.Load("Minigame1/Materials/BackPuzzle" + random + "_" + i) as Material;
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