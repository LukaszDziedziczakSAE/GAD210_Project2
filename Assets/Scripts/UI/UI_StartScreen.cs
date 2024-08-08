using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_StartScreen : MonoBehaviour
{
    [SerializeField] string surveyURL;
    [SerializeField] GameObject startScreen;
    [SerializeField] UI_EndingScreen endScreen;

    MatchState matchState;

    private void Awake()
    {
        matchState = FindAnyObjectByType<MatchState>();
    }

    private void Start()
    {
        if (matchState == null)
        {
            ShowStartingScreen();
        }
        else
        {
            ShowEndingScreen();
            endScreen.Initialize(matchState.Result);
            Destroy(matchState);
        }
    }

    public void OnStartButtonPress()
    {
        SceneManager.LoadScene(1);
    }

    public void OnSurveyButtonPress()
    {
        Application.OpenURL(surveyURL);
    }

    public void OnExitButtonPress()
    {
        Application.Quit();
    }

    public void ShowStartingScreen()
    {
        startScreen.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    public void ShowEndingScreen()
    {
        startScreen.SetActive(false);
        endScreen.gameObject.SetActive(true);
    }
}
