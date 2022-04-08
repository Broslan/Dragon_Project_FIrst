using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject OptionPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToOptions()
    {
        MainPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }

    public void GoToMain()
    {
        MainPanel.SetActive(true);
        OptionPanel.SetActive(false);
    }

    public void QuitQame()
    {
        Application.Quit();
    }
}
