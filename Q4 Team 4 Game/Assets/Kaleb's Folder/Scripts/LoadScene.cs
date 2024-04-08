using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    Scene scene;
    public static string nam;
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title Scene");
    }

    public void Credits()
    {
        scene = SceneManager.GetActiveScene();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Credits Scene");
        nam = scene.name;
    }

    public void ReturnFromCredits()
    {
        SceneManager.LoadScene(nam);
    }

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Scene");
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
