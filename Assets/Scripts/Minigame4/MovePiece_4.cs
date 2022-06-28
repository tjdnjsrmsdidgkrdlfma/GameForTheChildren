using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MovePiece_4 : MonoBehaviour
{
    float distance = 49.89f;
    Vector3 mousePosition;
    bool isclick = false;
    GameManager_4 gamemanager;
    float appearspeed = 0.02f;

    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager_4>();
    }

    void Update()
    {
        IsClicked();
    }

    void IsClicked()
    {
        if (Input.GetMouseButton(0))
        {
            isclick = true;
        }
        else
        {
            isclick = false;
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
        if (isclick == false)
        {
            if (other.CompareTag("PuzzlePlaceTag"))
            {
                if (String.Compare(this.gameObject.GetComponent<MeshRenderer>().material.name.Substring(0, 1), other.gameObject.name.Substring(7, 1)) == 0)
                {
                    this.transform.position = new Vector3(other.transform.position.x, 0.11f, other.transform.position.z);
                    gamemanager.numberofcorrect++;
                    Destroy(this.GetComponent<MovePiece_4>());
                }
            }
        }
    }
}
