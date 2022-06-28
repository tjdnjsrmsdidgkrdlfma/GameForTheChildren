using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager_6 : MonoBehaviour
{
    public bool[] check = new bool[4];
    int[] objects = new int[4];
    int[] shadows = new int[4];

    void Start()
    {
        int i;

        for (i = 0; i < 4; i++)
        {
            check[i] = false;
        }
        PutMaterials();
    }

    void Update()
    {
        if(CheckSuccess()==true)
        {
            this.gameObject.GetComponent<End>().EndMessage();
        }
    }

    void PutMaterials()
    {
        GameObject Objects = GameObject.Find("Objects");
        GameObject Shadows = GameObject.Find("Shadows");
        int i;

        SetRandomValue();

        for (i = 0; i < 4; i++)
        {
            Objects.transform.Find("Object (" + i + ")").GetComponent<MeshRenderer>().material = Resources.Load("Minigame6/Materials/0_" + objects[i]) as Material;
            Shadows.transform.Find("Shadow (" + i + ")").GetComponent<MeshRenderer>().material = Resources.Load("Minigame6/Materials/1_" + shadows[i]) as Material;
        }

        return;
    }

    void SetRandomValue()
    {
        objects[0] = UnityEngine.Random.Range(0, 4);
        do
        {
            objects[1] = UnityEngine.Random.Range(0, 4);
        } while (objects[1] == objects[0]);
        do
        {
            objects[2] = UnityEngine.Random.Range(0, 4);
        } while (objects[2] == objects[0] || objects[2] == objects[1]);
        do
        {
            objects[3] = UnityEngine.Random.Range(0, 4);
        } while (objects[3] == objects[0] || objects[3] == objects[1] || objects[3] == objects[2]);

        shadows[0] = UnityEngine.Random.Range(0, 4);
        do
        {
            shadows[1] = UnityEngine.Random.Range(0, 4);
        } while (shadows[1] == shadows[0]);
        do
        {
            shadows[2] = UnityEngine.Random.Range(0, 4);
        } while (shadows[2] == shadows[0] || shadows[2] == shadows[1]);
        do
        {
            shadows[3] = UnityEngine.Random.Range(0, 4);
        } while (shadows[3] == shadows[0] || shadows[3] == shadows[1] || shadows[3] == shadows[2]);

        return;
    }

    bool CheckSuccess()
    {
        if (!check.Contains(false))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
