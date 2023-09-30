using System.Collections;
using System.Collections.Generic;
using Core.Tag;
using UnityEngine;

public class PlayerPrefabsControl : MonoBehaviour
{
    public int CurrentLevelIndex;
    public int Coin;

    // Start is called before the first frame update
    void Start()
    {
        CurrentLevelIndex = PlayerPrefs.GetInt(TagList.CurrentLevelIndex);
        Coin = PlayerPrefs.GetInt(TagList.Coin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
