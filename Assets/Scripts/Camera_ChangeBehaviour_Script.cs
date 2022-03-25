using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ChangeBehaviour_Script : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera cameraViewDistance;
    public float CameraZoomDistanceDefault5;

    public float ResetCameraTimer;



    public GameObject cameraFollow_East;
    public GameObject cameraFollow_West;
    public GameObject CameraFollow_Down;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraChanger"))
        {
            cameraViewDistance.m_Lens.OrthographicSize = 10;
            cameraViewDistance.Follow = CameraFollow_Down.transform;
            Invoke("DefaultCameraZoom", ResetCameraTimer);

        }
    }



    private void DefaultCameraZoom()
    {
        cameraViewDistance.m_Lens.OrthographicSize = 5;
        cameraViewDistance.Follow = cameraFollow_East.transform;

    }

}
