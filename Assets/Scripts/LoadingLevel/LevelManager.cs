using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Tag;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TMP_Text loadingText;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey(TagList.CurrentLevelIndex))
        {
            PlayerPrefs.SetInt(TagList.CurrentLevelIndex, 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingBar());
        StartCoroutine(LevelControl());
    }

    IEnumerator LevelControl()
    {
        yield return new WaitForSeconds(1f);
       // Debug.Log(GetCurrentLevelIndex());
        SceneManager.LoadSceneAsync(GetCurrentLevelIndex());
    }

    private static int GetCurrentLevelIndex()
    {
        Variables.currentLevel = PlayerPrefs.GetInt(TagList.CurrentLevelIndex);
        return Variables.currentLevel;
    }

    public void LoadNextLevel()
    {
        PlayerPrefs.SetInt(TagList.CurrentLevelIndex, Variables.currentLevel + 1);
        SceneManager.LoadSceneAsync(GetCurrentLevelIndex());
    }

    public void SaveNextLevel()
    {
        PlayerPrefs.SetInt(TagList.CurrentLevelIndex, Variables.currentLevel + 1);  
    }
    
    IEnumerator LoadingBar()
    {
        while (true)
        {
            loadingText.text = "LOADING";
            yield return new WaitForSeconds(0.3f);
            loadingText.text = "LOADING.";
            yield return new WaitForSeconds(0.3f);
            loadingText.text = "LOADING..";
            yield return new WaitForSeconds(0.3f);
            loadingText.text = "LOADING...";
        }
    }
}
