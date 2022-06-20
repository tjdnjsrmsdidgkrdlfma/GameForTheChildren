using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PieceControl : MonoBehaviour
{
    float distance = 49.89f;
    Vector3 mousePosition;
    bool IsClick = false;
    GameManager_1 gamemanager;



    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager_1>();
        SetPosition();
    }

    void Update()
    {
        IsClicked();
    }

    void SetPosition()
    {
        float x, z;
        do
        {
            x = UnityEngine.Random.Range(-45f, 46f);

        } while (x >= -25 && x <= 25);
        z = UnityEngine.Random.Range(-23f, 24f);

        transform.position = new Vector3(x, 0.11f, z);

        return;
    }

    void IsClicked()
    {
        if (Input.GetMouseButton(0))
        {
            IsClick = true;
        }
        else
        {
            IsClick = false;
        }

        return;
    }

    void OnMouseDrag()
    {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;
    }

    void OnTriggerStay(Collider other)
    {
        if (IsClick == false)
        {
            if (other.CompareTag("PuzzlePlaceTag"))
            {
                if (String.Compare(this.gameObject.name.Substring(12, 3), other.gameObject.name.Substring(12, 3)) == 0)
                {
                    int a = GetNumber(this.gameObject.name.Substring(13, 2).ToString());
                    GameObject.Find("GameManager").GetComponent<GameManager_1>().PuzzleState[a] = true;
                    this.transform.position = new Vector3(other.transform.position.x, 0.11f, other.transform.position.z);
                    Destroy(this.GetComponent<PieceControl>());
                }
            }
        }
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
}
