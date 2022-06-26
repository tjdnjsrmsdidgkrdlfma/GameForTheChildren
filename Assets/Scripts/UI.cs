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
            Time.timeScale = 0;
        }
        else if (string.Compare(this.gameObject.name, "Cancel") == 0)
        {
            GameObject.Find("Canvas").transform.Find("UI").gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else if (string.Compare(this.gameObject.name, "QuitToList") == 0)
        {
            SceneManager.LoadScene("ChooseGames");
            Time.timeScale = 1;
        }

        return;
    }
}
