using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(status => { });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
