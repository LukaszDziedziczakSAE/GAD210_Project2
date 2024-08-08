using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }
    [Header("Ships")]
    [SerializeField] CapitalShip transportShip;
    [SerializeField] Mothership mothership;

    [Header("Referances")]
    [SerializeField] InputReader input;
    [SerializeField] CameraController cameraController;
    [SerializeField] SFX_StartingAudio startingAudio;
    [SerializeField] MatchState matchStatePrefab;

    public static InputReader Input => Instance.input;
    public static CapitalShip TransportShip => Instance.transportShip;
    public static Mothership Mothership => Instance.mothership;
    public static CameraController CameraController => Instance.cameraController;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        transportShip.ShipMovement.OnArrived += TransportArrived;
    }

    private void OnDisable()
    {
        transportShip.ShipMovement.OnArrived -= TransportArrived;
    }

    private void TransportArrived()
    {
        MatchState matchState = SpawnMatchState();
        matchState.Result = MatchState.EMatchResult.TransportSucess;
        ReturnToStartScreen();
    }

    public static void ReturnToStartScreen()
    {
        SceneManager.LoadScene(0);
    }

    public static void PlayStartSound()
    {
        Instance.startingAudio.PlayStartSound();
    }

    public static MatchState SpawnMatchState()
    {
        return Instantiate(Instance.matchStatePrefab, Vector3.zero, Quaternion.identity);
    }
}
