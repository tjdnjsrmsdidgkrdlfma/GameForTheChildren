using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager_2 : MonoBehaviour
{
    int repeattime = 0;
    public int maxrepeattime = 5;
    int random;
    public int numberofimages = 0;
    public bool[] TextState = new bool[3];

    void Start()
    {
        TextState = Enumerable.Repeat(true, 3).ToArray();
    }

    void Update()
    {
        while (repeattime < maxrepeattime && CheckState())
        {
            random = UnityEngine.Random.Range(0, numberofimages);
            PutImage();
            PutText();
            SetPosition();
            ActiveScript();
            repeattime++;
            TextState = Enumerable.Repeat(false, 3).ToArray();
        }
    }

    void PutImage()
    {
        GameObject.Find("RawImage").GetComponent<RawImage>().texture = Resources.Load<Texture>("Minigame2/Textures/Texture" + random);

        return;
    }

    void PutText()
    {
        GameObject.Find("Piece (0)").GetComponent<MeshRenderer>().material = Resources.Load("Minigame2/Materials/Text" + random + "_" + "0") as Material;
        GameObject.Find("Piece (1)").GetComponent<MeshRenderer>().material = Resources.Load("Minigame2/Materials/Text" + random + "_" + "1") as Material;
        GameObject.Find("Piece (2)").GetComponent<MeshRenderer>().material = Resources.Load("Minigame2/Materials/Text" + random + "_" + "2") as Material;
        return;
    }

    void SetPosition()
    {
        int i, j, k;
        bool[] l = { false, false, false };

        for (i = 0; i < 3; i++)
        {
            do
            {
                j = UnityEngine.Random.Range(0, 3);
            } while (l[j] == true);

            l[j] = true;

            k = i * -19 - 2;
            GameObject.Find("Piece (" + j + ")").transform.position = new Vector3(k, 0.1f, 10);
        }

        return;
    }

    void ActiveScript()
    {
        int i;

        for (i = 0; i < 3; i++)
        {
            GameObject.Find("Piece (" + i + ")").GetComponent<PieceControl_2>().enabled = true;
        }

        return;
    }

    bool CheckState()
    {
        if (!TextState.Contains(false))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
