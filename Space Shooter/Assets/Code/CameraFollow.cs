using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerShip>().transform;
    }


    void Update()
    {
        if(player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, -10);
        }
    }
}
