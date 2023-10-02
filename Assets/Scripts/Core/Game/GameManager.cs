using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Tag;
using GoogleMobileAds.Api;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RewardedAds _RewardedAds;
    public InterstitialAds _InterstitialAds;
    private int _currentLevelReward;
    private void OnTriggerEnter(Collider other)
    {
        //IF FINISH TO LEVEL AND HIT LEVEL FINSH LINE
        if (other.gameObject.CompareTag(TagList.Player) && this.gameObject.CompareTag(TagList.FinishLine))
        {
            SaveControler saveControler = new SaveControler();
            LevelManager levelManager = new LevelManager();
            _RewardedAds.LoadRewardedAd();
            _InterstitialAds.LoadLoadInterstitialAd();
            levelManager.SaveNextLevel();
            Variables.firstTouch = 0;
            Variables.GameCondition = Variables.GC_NEXTLEVEL;
        }
    }
}
