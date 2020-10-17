using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    private float distance;
    private Vector3 playerPrevPos, playerMoveDir;

    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.position - transform.position;

        distance = offset.magnitude;
        playerPrevPos = player.transform.position;
    }

    // LateUpdate is called once per frame, after Update
    void LateUpdate()
    {
        playerMoveDir = player.transform.position - playerPrevPos;
        playerMoveDir.Normalize();
        transform.position = player.transform.position - distance * playerMoveDir;

        transform.LookAt(player.transform.position);

        playerPrevPos = player.transform.position;
    }
}
