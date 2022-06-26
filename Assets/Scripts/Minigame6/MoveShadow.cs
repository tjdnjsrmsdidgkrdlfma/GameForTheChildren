using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveShadow : MonoBehaviour
{
    GameManager_6 GameManager;
    float distance = 49.79f;
    Vector3 mousePosition;
    bool isclick = false;

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager_6>();
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
            if (other.CompareTag("Object"))
            {
                if (String.Compare(this.gameObject.GetComponent<MeshRenderer>().material.name.Substring(2, 1), other.gameObject.GetComponent<MeshRenderer>().material.name.Substring(2, 1)) == 0)
                {
                    this.transform.position = new Vector3(other.transform.position.x, 0.11f, other.transform.position.z);
                    GameManager.check[Convert.ToInt32(this.gameObject.GetComponent<MeshRenderer>().material.name.Substring(2, 1))] = true;
                    Destroy(this.GetComponent<MoveShadow>());
                }
            }
        }
    }
}
