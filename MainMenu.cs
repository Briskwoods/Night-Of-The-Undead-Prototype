using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private GameObject MainMenuPanel;
    private GameObject ControlsPanel;

    public void Start()
    {
        MainMenuPanel  = GameObject.FindGameObjectWithTag("MainMenuUI");
        ControlsPanel = GameObject.FindGameObjectWithTag("ControlsUI");
        ControlsPanel.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        {
            //If we are running in a standalone build of the game
#if UNITY_STANDALONE
            //Quit the application
            Application.Quit();
#endif

            //If we are running in the editor
#if UNITY_EDITOR
            //Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    public void Controls(){
        ControlsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }
    public void Back(){
        MainMenuPanel.SetActive(true);
        ControlsPanel.SetActive(false);

    }
}
