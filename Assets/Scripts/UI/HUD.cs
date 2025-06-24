using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject MainMenu;
    public GameObject OptionMenu;
    private bool isPaused = false;

    void Awake()
    {
        OptionMenu.SetActive(false);
        PauseMenu.SetActive(false);
        MainMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(isPaused)
            {
                ResumeButton_OnClick();
            }
            else
            {
                PauseButton_OnClick(); 
            }
        }
    }

    public void ResumeButton_OnClick()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PlayButton_OnClick()
    {
        MainMenu.SetActive(false);
    }

    public void ExitButton_OnClick()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OptionButton_OnClick()
    {
        MainMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void PauseButton_OnClick()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitButton_OnClick()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {

    }

    public void BackButton_OnClick()
    {
        PauseMenu.SetActive(true);
        OptionMenu.SetActive(false);
    }
}
