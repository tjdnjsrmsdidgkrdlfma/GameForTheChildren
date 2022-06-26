using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager_5 : MonoBehaviour
{
    public int maxrepeattime;
    public int[] number = new int[3];
    public int choose;

    void Start()
    {
        SetDefaultValue();
        PutMaterials();
        StartCoroutine(MainGameController());
    }

    void Update()
    {
        if (choose != -1)
        {
            Check();
        }
    }

    void SetDefaultValue()
    {
        int i;

        maxrepeattime = UnityEngine.Random.Range(5, 31);
        choose = -1;

        for (i = 0; i < 3; i++)
        {
            number[i] = 0;
        }

        for (i = 0; i < 3; i++)
        {
            GameObject.Find("BearButton (" + i + ")").gameObject.SetActive(false);
        }

        return;
    }

    void PutMaterials()
    {
        GameObject Bears = GameObject.Find("Bears");
        int i;

        for (i = 0; i < 3; i++)
        {
            Bears.transform.Find("Bear (" + i + ")").GetComponent<RawImage>().texture = Resources.Load("Minigame5/Textures/bear") as Texture;
        }

        return;
    }

    IEnumerator MainGameController()
    {
        int random;
        int repeattime = 0;
        GameObject Bears = GameObject.Find("Bears");

        while (true)
        {
            random = UnityEngine.Random.Range(0, 3);

            Bears.transform.Find("Bear (" + random + ")").GetComponent<RawImage>().texture = Resources.Load("Minigame5/Textures/eatingbear") as Texture;
            yield return new WaitForSeconds(0.3f);

            Bears.transform.Find("Bear (" + random + ")").GetComponent<RawImage>().texture = Resources.Load("Minigame5/Textures/bear") as Texture;
            number[random]++;
            repeattime++;
            yield return new WaitForSeconds(1);

            if (repeattime >= maxrepeattime)
            {
                if (number[0] != number[1] && number[1] != number[2] && number[2] != number[0])
                {
                    break;
                }
            }
        }

        ActiveButtons();

        yield break;
    }

    void ActiveButtons()
    {
        GameObject BearButtons = GameObject.Find("BearButtons");
        int i;

        for (i = 0; i < 3; i++)
        {
            BearButtons.transform.Find("BearButton (" + i + ")").gameObject.SetActive(true);
        }

        return;
    }

    bool Check()
    {
        int bearatemost;

        if (number[0] >= number[1] && number[0] >= number[2])
        {
            bearatemost = 0;
        }
        else if (number[1] >= number[0] && number[1] >= number[2])
        {
            bearatemost = 1;
        }
        else
        {
            bearatemost = 2;
        }

        if (bearatemost == choose)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
