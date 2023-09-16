using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaclesController : MonoBehaviour
{
    public Obstacles[] LevelDesign;
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
            if (SceneManager.GetActiveScene().name == "Level-" + i)
            {
                Debug.LogWarning("Girdiii");
                if (gameObject.CompareTag("asd"))
                {
                    
                }
                _renderer.material.color = LevelDesign[i - 1].MyColor;
            }
        }
    }
}
