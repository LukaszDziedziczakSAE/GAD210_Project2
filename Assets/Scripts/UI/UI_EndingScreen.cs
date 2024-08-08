using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_EndingScreen : MonoBehaviour
{
    [SerializeField] TMP_Text endText;
    [SerializeField] UI_StartScreen startScreen;

    public void Initialize(MatchState.EMatchResult result)
    {
        switch(result)
        {
            case MatchState.EMatchResult.TransportSucess:
                endText.text = "Transport Safely Arrived";
                break;

            case MatchState.EMatchResult.TransportDestroyed:
                endText.text = "Transport Was Destroyed";
                break;

            case MatchState.EMatchResult.MothershipDestroyed:
                endText.text = "Mothership Was Destroyed";
                break;
        }
    }

    public void OnReturnToMenuButtonPress()
    {
        startScreen.ShowStartingScreen();
    }
}
