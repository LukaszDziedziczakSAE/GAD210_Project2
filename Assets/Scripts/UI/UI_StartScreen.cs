using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_StartScreen : MonoBehaviour
{
    [SerializeField] string surveyURL;

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
}
