using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void GeneralTutorial()
    {
        SceneManager.LoadScene("General Tutorial");
    }
    public void ExitTutorial()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Tutorials()
    {
        SceneManager.LoadScene("Tutorial Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
