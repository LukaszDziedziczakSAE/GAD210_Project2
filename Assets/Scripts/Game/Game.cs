using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }
    [SerializeField] InputReader input;
    [SerializeField] CapitalShip transportShip;
    [SerializeField] Mothership mothership;
    [SerializeField] CameraController cameraController;

    public static InputReader Input => Instance.input;
    public static CapitalShip TransportShip => Instance.transportShip;
    public static Mothership Mothership => Instance.mothership;
    public static CameraController CameraController => Instance.cameraController;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        transportShip.ShipMovement.OnArrived += ReturnToStartScreen;
    }

    private void OnDisable()
    {
        transportShip.ShipMovement.OnArrived -= ReturnToStartScreen;
    }

    public static void ReturnToStartScreen()
    {
        SceneManager.LoadScene(0);
    }
}
