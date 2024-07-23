using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera playCamera;



    private void Update()
    {
        playCamera.transform.position = new Vector3(Game.Mothership.transform.position.x, playCamera.transform.position.y, Game.Mothership.transform.position.z);
    }
}
