using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playCamera;
    [SerializeField] CinemachineBrain brain;

    CinemachineVirtualCamera upgradeCamera;

    public bool InTurretCameraMode => upgradeCamera != null;
    public bool InPlayCameraMode => playCamera.Priority == 10;

    private void Update()
    {
        playCamera.transform.position = new Vector3(Game.Mothership.transform.position.x, playCamera.transform.position.y, Game.Mothership.transform.position.z);
    }

    public void SwitchToMothershipCamera()
    {
        if (upgradeCamera != null)
        {
            upgradeCamera.Priority = 5;
            upgradeCamera = null;
        }
        playCamera.Priority = 5;
        Game.Mothership.Camera.Priority = 10;
    }

    public void SwitchToPlayCamera()
    {
        if (upgradeCamera != null)
        {
            upgradeCamera.Priority = 5;
            upgradeCamera = null;
        }
        Game.Mothership.Camera.Priority = 5;
        playCamera.Priority = 10;
    }

    public void SwitchToTurretCamera(CinemachineVirtualCamera turretCam)
    {
        Game.Mothership.Camera.Priority = 5;
        playCamera.Priority = 5;
        upgradeCamera = turretCam;
        upgradeCamera.Priority = 10;
    }
}
