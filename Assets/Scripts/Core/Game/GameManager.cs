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
    private void OnTriggerEnter(Collider other)
    {
        //IF FINISH TO LEVEL AND HIT LEVEL FINSH LINE
        if (other.gameObject.CompareTag(TagList.Player) && this.gameObject.CompareTag(TagList.FinishLine))
        {
            LevelManager levelManager = new LevelManager();
            levelManager.SaveNextLevel();
            Variables.GameCondition = Variables.GC_NEXTLEVEL;
            _rewardedAds.LoadRewardedAd();
            _interstitialAds.LoadLoadInterstitialAd();
            Variables.firstTouch = 0;
        }
    }
}
