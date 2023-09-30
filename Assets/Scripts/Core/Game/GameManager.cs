using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Tag;
using GoogleMobileAds.Api;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RewardedAds _rewardedAds;
    [SerializeField] private InterstitialAds _interstitialAds;
    private int _currentLevelReward;
    private void OnTriggerEnter(Collider other)
    {
        //IF FINISH TO LEVEL AND HIT LEVEL FINSH LINE
        if (other.gameObject.CompareTag(TagList.Player) && this.gameObject.CompareTag(TagList.FinishLine))
        {
            SaveControler saveControler = new SaveControler();
            LevelManager levelManager = new LevelManager();
            levelManager.SaveNextLevel();
          //  saveControler.AddCoin(100);
            _rewardedAds.LoadRewardedAd();
            _interstitialAds.LoadLoadInterstitialAd();
            Variables.firstTouch = 0;
            Variables.GameCondition = Variables.GC_NEXTLEVEL;
        }
    }
}
