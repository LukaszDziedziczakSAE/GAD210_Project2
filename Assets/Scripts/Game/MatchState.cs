using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchState : MonoBehaviour
{
    public EMatchResult Result;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public enum EMatchResult
    {
        TransportSucess,
        TransportDestroyed,
        MothershipDestroyed
    }

}
