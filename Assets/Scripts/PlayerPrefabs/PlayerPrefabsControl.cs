using System.Collections;
using System.Collections.Generic;
using Core.Tag;
using UnityEngine;

public class PlayerPrefabsControl : MonoBehaviour
{
    public int CurrentLevelIndex;

    // Start is called before the first frame update
    void Start()
    {
        CurrentLevelIndex = PlayerPrefs.GetInt(TagList.CurrentLevelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
