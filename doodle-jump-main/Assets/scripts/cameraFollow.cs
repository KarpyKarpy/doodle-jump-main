using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;

    //moves the camera with the player
    private void LateUpdate()
    {
        transform.position = new Vector3(
            player.position.x,
            player.position.y,
            -10);
    }
}
