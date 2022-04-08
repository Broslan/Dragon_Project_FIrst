using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;
    [SerializeField] private GameObject mainGUI;
    [SerializeField] private GameObject dragNDropGUI;
    [SerializeField] private GameObject[] objectForDefeatOn;
    [SerializeField] private GameObject[] objectForDefeatOff;
    private bool isLoose = false;
    
    private void Awake()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isLoose)
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        mainGUI.SetActive(true);
        dragNDropGUI.SetActive(true);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        mainGUI.SetActive(false);
        dragNDropGUI.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadShop()
    {
        SceneManager.LoadScene(2);
    }

    public void OnDefeat()
    {
        isLoose = true;
        Pause();
        foreach (GameObject obj in objectForDefeatOn)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in objectForDefeatOff)
        {
            obj.SetActive(false);
        }
    }
}
