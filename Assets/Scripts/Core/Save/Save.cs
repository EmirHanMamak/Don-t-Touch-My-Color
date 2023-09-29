using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static Save saveInstance;
    public static int currentLevel;
    public static int cointCount;
    private void Start()
    {
        if (saveInstance == null)
        {
            saveInstance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != saveInstance)
        {
            Destroy(gameObject);
        }
    }

    public void SetLevelIndex(int level)
    {
        currentLevel = level;
    }
}
