using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnButtonClick()
    {
        if (string.Compare(this.gameObject.name, "ChooseGames") == 0)
        {
            SceneManager.LoadScene("ChooseGames");
        }
        else if (string.Compare(this.gameObject.name, "ShowCredit") == 0)
        {
            GameObject.Find("Canvas").transform.Find("Credit").gameObject.SetActive(true);
        }
        else if (string.Compare(this.gameObject.name, "ExitGame") == 0)
        {
            Application.Quit();
        }

        return;
    }
}
