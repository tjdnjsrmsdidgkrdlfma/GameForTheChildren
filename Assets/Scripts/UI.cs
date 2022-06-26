using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnButtonClick()
    {
        if(string.Compare(this.gameObject.name, "UIButton") == 0)
        {
            GameObject.Find("Canvas").transform.Find("UI").gameObject.SetActive(true);
        }
        else if (string.Compare(this.gameObject.name, "Cancel") == 0)
        {
            GameObject.Find("Canvas").transform.Find("UI").gameObject.SetActive(false);
        }
        else if (string.Compare(this.gameObject.name, "QuitToList") == 0)
        {
            SceneManager.LoadScene("ChooseGames");
        }

        return;
    }
}