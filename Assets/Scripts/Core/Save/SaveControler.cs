using System;
using System.Collections;
using System.Collections.Generic;
using Core.Tag;
using TMPro;
using UnityEngine;

public class SaveControler : MonoBehaviour
{
    /*
     * Coin
     */
    //public static SaveControler SaveControlerStatic;
    [SerializeField] private TMP_Text coinLabel;
    private void Start()
    {
        coinLabel.text = GetCoin().ToString();
        if (!PlayerPrefs.HasKey(TagList.Coin))
        {
            PlayerPrefs.SetInt(TagList.Coin, 0);
        }
    }
    
    public void AddCoin(int amount)
    {
        SetCoinPlayerPrefs(amount);
        coinLabel.text = GetCoin().ToString();
    }

    public int GetCoin()
    {
        return PlayerPrefs.GetInt(TagList.Coin);
    }
    private void SetCoinPlayerPrefs(int amount)
    {
        int oldCoin = PlayerPrefs.GetInt(TagList.Coin);
        PlayerPrefs.SetInt(TagList.Coin, amount + oldCoin);
    }
}
