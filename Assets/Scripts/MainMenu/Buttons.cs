using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    GameObject CreditsScreen, MenuButtons;

    bool ShowingCredits;

    private void Start()
    {
        ShowingCredits = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ToggleCredits()
    {
        ShowingCredits = !ShowingCredits;

        MenuButtons.SetActive(!ShowingCredits);
        CreditsScreen.SetActive(ShowingCredits);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
