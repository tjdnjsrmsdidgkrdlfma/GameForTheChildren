using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PieceControl_2 : MonoBehaviour
{
    float distance = 49.89f;
    Vector3 mousePosition;
    bool IsClick = false;

    void Start()
    {

    }

    void Update()
    {
        IsClicking();
    }

    void IsClicking()
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
                if (String.Compare(this.gameObject.name.Substring(7, 1), other.gameObject.name.Substring(7, 1)) == 0)
                {
                    GameObject.Find("GameManager").GetComponent<GameManager_2>().TextState[Convert.ToInt32(this.gameObject.name.Substring(7, 1))] = true;
                    this.transform.position = new Vector3(other.transform.position.x, 0.11f, other.transform.position.z);
                    this.GetComponent<PieceControl_2>().enabled = false;
                }
            }
        }
    }
}
