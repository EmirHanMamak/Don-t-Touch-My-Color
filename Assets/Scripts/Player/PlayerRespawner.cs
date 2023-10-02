using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Tag;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawner : MonoBehaviour
{
    public PlayerControler player;
    private float playerCurrentPos = 0;
    public bool isPlayerCrash = false;
    public GameObject[] spawnPoints;
    private float distance;
    private float nearestDistance = 10000f;
    private GameObject nearestDistanceObject;

    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag(TagList.SpawnPoints);
    }
    
    public void NearestPlayerSpawner()
    {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Debug.Log("inside222");

                distance = Vector3.Distance(this.transform.position, spawnPoints[i].transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistanceObject = spawnPoints[i].gameObject;
                    Debug.Log("this it" + spawnPoints[i]);
                }
            }
            Time.timeScale = 1f;
            player.RestartPlayerSettings();
            player.gameObject.transform.position = nearestDistanceObject.transform.position;
    }
    
}
