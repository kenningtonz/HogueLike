using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    public Data data;
    public Data playerdata;
    public GameObject credits;
    public bool startgame = false;
    public void main()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void cutscene()
    {
        SceneManager.LoadScene("CutScene");
    }

    public void play()
    {
        if(startgame)
        {

            data.contin = false;
        }
        SceneManager.LoadScene("SampleScene");
    }
    public void quit()
    {
        Application.Quit();
    }

    public void back()
    {
        credits.gameObject.SetActive(false);
    }
    public void Credits()
    {
        credits.gameObject.SetActive(true);
    }

}
