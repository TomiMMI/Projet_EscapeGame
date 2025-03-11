using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManipulator : MonoBehaviour
{
    public static CameraManipulator Instance { get; private set; }
    public CinemachinePOV cameraPlayer;
    void Start()
    {
        Instance = this;
        cameraPlayer = GameObject.FindGameObjectWithTag("Virtual Camera").GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetRotation(float rotation)
    {
        cameraPlayer.m_HorizontalAxis.Value = rotation;
    }
}

