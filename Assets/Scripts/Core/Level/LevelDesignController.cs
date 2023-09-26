using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Core.Level
{
    public class LevelDesignController : MonoBehaviour
    {
        public LevelDesign[] LevelDesign;
        private Renderer _renderer;
        private SceneManager _sceneManager;
        
        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }
        private void Start()
        {
    
            Debug.Log(SceneManager.GetActiveScene().name);
            for (int i = 0; i < LevelDesign.Length; i++)
            {
                Debug.LogWarning("Level-" + i);
                if (SceneManager.GetActiveScene().name == "Level-" + i)
                {
                    //Debug.LogWarning("Level-" + i);
                    //Friendly Obstacles
                    ForFriendly(i);
                    //Enemy Obstacles
                    ForEnemy(i);
                    //Player
                    ForPlayer(i);
                    //Ground
                    ForGrounds(i);
                }
            }
        }
        private void ForPlayer(int i)
        {
            if (gameObject.CompareTag("Player"))
            {
                GameObject player = gameObject.transform.GetChild(0).gameObject;
                foreach (Transform child in player.transform)
                {
                    Renderer renderer = new Renderer();
                    child.GetComponent<Renderer>().material.color = LevelDesign[i - 1].MyPlayerColor;
                }
            }
        }
        private void ForEnemy(int i)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                _renderer.material.color = LevelDesign[i - 1].EnemyColor;
            }
        }
    
        private void ForFriendly(int i)
        {
            if (gameObject.CompareTag("Friendly"))
            {
                _renderer.material.color = LevelDesign[i - 1].FriendlyColor;
            }
        }
        private void ForGrounds(int i)
        {
            if (gameObject.CompareTag("Ground"))
            {
                _renderer.material.color = LevelDesign[i - 1].GroundColor;
            }
        }
    }
}
