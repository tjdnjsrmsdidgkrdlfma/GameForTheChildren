using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene("Minigame" + this.gameObject.name.Substring(8, 1));

        return;
    }
}
