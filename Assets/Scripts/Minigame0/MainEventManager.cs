using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainEventManager : MonoBehaviour
{
    [Header("물건 목록")]
    [SerializeField]
    public string[] objects = new string[] { "Pencil", "Eraser", "Ruler", "Scissor", "Glue", "Notebook" };
    public Texture[] images;

    int object0, object1, object2;
    int flag;
    int maxlooptime = 5;
    int looptime = 0;
    bool isend = true;
    public bool button0 = false, button1 = false, button2 = false;
    bool isdelay = false;
    float appearspeed = 0.05f;

    void Start()
    {

    }

    void Update()
    {
        if (looptime == maxlooptime && isdelay == false)
        {
            GameObject.Find("CorrectImage").GetComponent<RawImage>().enabled = true;
            StartCoroutine(ShowCorrect());
        }
        while (looptime < maxlooptime && isend)
        {
            Setting();
        }
        CheckFlag();
    }

    IEnumerator ShowCorrect()
    {
        isdelay = true;

        GameObject gameobject = GameObject.Find("CorrectImage");
        Color color = GameObject.Find("CorrectImage").GetComponent<RawImage>().color;

        color.a += appearspeed;

        gameobject.GetComponent<RawImage>().color = color;

        if (color.a == 1)
        {
            yield break;
        }

        yield return null;

        isdelay = false;
    }

    void Setting()
    {
        object0 = UnityEngine.Random.Range(0, 6);
        object1 = UnityEngine.Random.Range(0, 6);
        while (object0 == object1)
        {
            object1 = UnityEngine.Random.Range(0, 6);
        }
        object2 = UnityEngine.Random.Range(0, 6);
        while (object0 == object2 || object1 == object2)
        {
            object2 = UnityEngine.Random.Range(0, 6);
        }
        flag = UnityEngine.Random.Range(0, 3);

        GameObject.Find("Button0").GetComponentInChildren<Text>().text = objects[object0];
        GameObject.Find("Button1").GetComponentInChildren<Text>().text = objects[object1];
        GameObject.Find("Button2").GetComponentInChildren<Text>().text = objects[object2];

        GameObject.Find("Picture").GetComponent<RawImage>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 1f);
        images = Resources.LoadAll<Texture>("Textures");

        switch (flag)
        {
            case 0:
                foreach (Texture image in images)
                {
                    if (String.Compare(image.ToString(), objects[object0] + " (UnityEngine.Texture2D)") == 0)
                    {
                        GameObject.Find("Picture").GetComponent<RawImage>().texture = image;
                    }
                }
                break;
            case 1:
                foreach (Texture image in images)
                {
                    if (String.Compare(image.ToString(), objects[object1] + " (UnityEngine.Texture2D)") == 0)
                    {
                        GameObject.Find("Picture").GetComponent<RawImage>().texture = image;
                    }
                }
                break;
            case 2:
                foreach (Texture image in images)
                {
                    if (String.Compare(image.ToString(), objects[object2] + " (UnityEngine.Texture2D)") == 0)
                    {
                        GameObject.Find("Picture").GetComponent<RawImage>().texture = image;
                    }
                }
                break;
        }

        isend = false;
    }

    void CheckFlag()
    {
        if (button0)
        {
            if (flag == 0)
            {
                Debug.Log("Correct");
                looptime++;
                isend = true;
                //GameObject.Find("CorrectAnswer").GetComponent<Text>().color = new Color(0f, 0f, 0f, 1f);
            }
            else
            {
                Debug.Log("Wrong");
            }
            button0 = false;
        }
        else if (button1)
        {
            if (flag == 1)
            {
                Debug.Log("Correct");
                looptime++;
                isend = true;
                //GameObject.Find("CorrectAnswer").GetComponent<Text>().color = new Color(0f, 0f, 0f, 1f);
            }
            else
            {
                Debug.Log("Wrong");
            }
            button1 = false;
        }
        else if (button2)
        {
            if (flag == 2)
            {
                Debug.Log("Correct");
                looptime++;
                isend = true;
                //GameObject.Find("CorrectAnswer").GetComponent<Text>().color = new Color(0f, 0f, 0f, 1f);
            }
            else
            {
                Debug.Log("Wrong");
            }
            button2 = false;
        }
    }
}

/*blic Image TestImage; //기존에 존재하는 이미지
public Sprite TestSprite; //바뀌어질 이미지

public void ChangeImage()
{
    TestImage.sprite = TestSprite; //TestImage에 SourceImage를 TestSprite에 존제하는 이미지로 바꾸어줍니다
}*/

//GameObject.Find("Picture").GetComponent<RawImage>().texture = Resources.Load<Texture>("Scissor");
//GetComponent<>(). = Resources.Load<Sprite>("Scissor");