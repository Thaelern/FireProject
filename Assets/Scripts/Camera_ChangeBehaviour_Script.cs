using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ChangeBehaviour_Script : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera cameraViewDistance;
    public float CameraZoomDistanceDefault5;

    public float ResetCameraTimer;
     


    public GameObject cameraFollow;
    public Transform playerController_trsform;
    private Vector2 player_gOjt;

    public float maxRangeCam;
    public float cameraFollowSpeed;

    public float cameraResetDistancePerFrame;

    private void Update()
    {
        // current position of the player transform
        player_gOjt = playerController_trsform.position;
    }


    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraChanger"))
        {
            cameraViewDistance.m_Lens.OrthographicSize = 10;
            //cameraViewDistance.Follow = CameraFollow_Down.transform;
            Invoke("DefaultCameraZoom", ResetCameraTimer);

        }
    }
    */

    public void CameraFollowRightFunc()
    {
        // limit range the camera can move player transform + 3 units ??
        // 1st, get player.pos.x 2nd. get cameraFollow pos. 3rd max range those 2 + 3

        // max travel range
        if(cameraFollow.transform.position.x <= player_gOjt.x + maxRangeCam)
        {
            cameraFollow.transform.Translate(Vector3.right * Time.deltaTime * cameraFollowSpeed);
        }
    }

    public void CameraFollowLeftFunc()
    {
        if (cameraFollow.transform.position.x >= player_gOjt.x + -maxRangeCam)
        {
            cameraFollow.transform.Translate(-Vector3.right * Time.deltaTime * cameraFollowSpeed);
        }
    }

    public void cameraFollowReturnCenter()
    {
        if(cameraFollow.transform.position.x != player_gOjt.x)
        {
            cameraFollow.transform.position = Vector2.MoveTowards(cameraFollow.transform.position, playerController_trsform.position,cameraResetDistancePerFrame * Time.deltaTime)  ;
        }
    }



}
