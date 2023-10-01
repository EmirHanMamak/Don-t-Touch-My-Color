using System;
using System.Collections;
using System.Collections.Generic;
using Core.Tag;
using Player;
using UnityEngine;

public class PlayerRespawner : MonoBehaviour
{
    private PlayerControler player;
    private float playerCurrentPos = 0;
    public bool isPlayerCrash = false;
    public GameObject[] spawnPoints;
    private float distance;
    private float nearestDistance = 10000f;
    public GameObject newPlayer;

    private void Awake()
    {
        player = GetComponent<PlayerControler>();
    }

    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag(TagList.SpawnPoints);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagList.Player))
        {
            Debug.Log("inside111");
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Debug.Log("inside222");

                distance = Vector3.Distance(this.transform.position, spawnPoints[i].transform.position);
                if (distance < nearestDistance)
                {
                    Debug.Log("inside333");

                    player.transform.position = spawnPoints[i].transform.position;
                    nearestDistance = distance;
                }
            }
        }

    }

    public void SetPlayerZPos(float currentPlayerZPos)
    {
        playerCurrentPos = currentPlayerZPos;
    }
}
