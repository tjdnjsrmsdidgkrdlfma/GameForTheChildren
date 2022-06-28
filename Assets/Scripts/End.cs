using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    float appearspeed = 0.02f;
    float delaytime = 1.5f;
    bool isshown = false;
    bool isdelay = true;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EndMessage()
    {
        GameObject.Find("Canvas").transform.Find("End").gameObject.SetActive(true);

        return;
    }

    public void OnButtonClick()
    {
        if (string.Compare(this.gameObject.name, "ReturnToList") == 0)
        {
            SceneManager.LoadScene("ChooseGames");
            Time.timeScale = 1;
        }

        return;
    }
}
